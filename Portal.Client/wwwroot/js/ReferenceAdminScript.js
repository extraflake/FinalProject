var table = null;
$(document).ready(function () {
    console.log("ready!");
    $.ajax({
        "type": "GET",
        "url": "/Admin/GetReference",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            qt = qt.data
            console.log(qt);
            table = $('#table1').DataTable({
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
                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ');"><i data-feather="trash">Delete</i></button>'
                        }
                    }]
            });
        }
    });
});


function Save() {
    debugger;
    var Reference = new Object();
    Reference.Name = $('#Name').val();
    if (Reference.Name == '') {
        Swal.fire('Error', 'Please Input Reference Name', 'error');
        ClearScreen();
    } else {
        $.ajax({
            type: 'POST',
            url: '/Admin/AddReference',
            data: Reference
        }).then((result) => {
            debugger;
            if (result != "GAGAL") {
                Swal.fire({
                    position: 'center',
                    type: 'success',
                    icon: 'success',
                    title: 'Reference Added Successfully'
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

function GetById(Id) {
    $('#Id').val("");
    $('#Name').val("");
    $('#Update').show();
    $('#Save').hide();
    debugger;
    $.ajax({
        url: "/Admin/GetByIdReference/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            const obj = JSON.parse(result);
            $('#Id').val(obj.Id);
            $('#Name').val(obj.Name);
            $('#myModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Update() {
    debugger;
    var Department = new Object();
    Department.Id = $('#Id').val();
    Department.Name = $('#Name').val();
    if (Department.Name == '') {
        Swal.fire('Error', 'Please Input Reference Name', 'error');
        ClearScreen();
    } else {
        $.ajax({
            type: 'POST',
            url: '/Admin/Update',
            data: Department
        }).then((result) => {
            debugger;
            if (result.StatusCode == 200) {
                Swal.fire({
                    position: 'center',
                    icon: 'success',
                    type: 'success',
                    title: 'Department Update Successfully'
                });
                table.ajax.reload();
            } else {
                Swal.fire('Error', 'Failed to Update', 'error');
                ClearScreen();
                table.ajax.reload();
            }
        })
    }
}

function Delete(Id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.value) {
            debugger;
            $.ajax({
                url: "/Admin/DeleteReference/",
                data: { Id: Id },
            }).then((result) => {
                debugger;
                if (result!= "GAGAL") {
                    Swal.fire({
                        position: 'center',
                        icon: 'success',
                        type: 'success',
                        title: 'Delete Successfully'
                    });
                    table.ajax.reload();
                }
                else {
                    Swal.fire('Error', 'Failed to Delete', 'error');
                    ClearScreen();
                }
            })
        };
    });
}


function ClearScreen() {
    $('#Id').val("");
    $('#Name').val("");
    $('#Update').hide();
    $('#Save').show();
}