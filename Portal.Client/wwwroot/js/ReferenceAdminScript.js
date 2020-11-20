var table = null;

$(document).ready(function () {
    console.log("ready!");
    $.ajax({
        "type": "GET",
        "url": "/Admin/Get",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            qt = qt.data
            console.log(qt);
            $('#table1').DataTable({
                data: qt,
                "oLanguage": {
                    "sSearch": "Search : "
                },
                columns: [
                    {
                        render: function (data, type, row, meta) {
                            return meta.row + meta.settings._iDisplayStart + 1;
                        }
                    },
                    {
                        "data": "id",
                        "visible": false
                    },
                    { "data": "name" },
                    {
                        "data": "applicants",
                        "visible": false
                    },
                    {
                        "render": function (data, type, row) {
                            return '<button class="btn pull-left hidden-sm-down btn-warning" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i data-feather="edit">Edit</i></button >' + '&nbsp;' +
                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteSchedule(' + row.id + ');"><i data-feather="trash">Delete</i></button>'
                        }
                    }]
            });
        }
    });
});
function Save() {
    debugger;
    var Department = new Object();
    Department.Name = $('#Name').val();
    Department.Tanggal = $('#Date').val();
    if (Department.Name == '') {
        Swal.fire('Error', 'Please Input Department Name', 'error');
        ClearScreen();
    } else {
        $.ajax({
            type: 'POST',
            url: '/Departments/Insert',
            data: Department
        }).then((result) => {
            debugger;
            if (result.StatusCode == 200) {
                Swal.fire({
                    position: 'center',
                    type: 'success',
                    icon: 'success',
                    title: 'Department Added Successfully'
                });
                table.ajax.reload();
            } else {
                Swal.fire('Error', 'Failed to Input', 'error');
                ClearScreen();
                table.ajax.reload();
            }
        })
    }
}


function ClearScreen() {
    $('#Id').val("");
    $('#Name').val("");
    $('#Update').hide();
    $('#Save').show();
}