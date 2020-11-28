var table = null;
$(document).ready(function () {
    console.log("Bisa masuk!");
    table = $('#table1').DataTable({
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "ajax": {
            "url": "/Admin/GetApplicant",
            "type": "GET",
            "datatype": "json"
        },
        "datasrc": "data",
        columns: [
            {
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "id"
                //"visible": false
            },
            {
                "data": "alreadyCheck",
                "render": function (data, type, row, meta) {
                    if (data == false) {
                        return '<span>Test Complete</span>'
                    }
                    else
                    {
                        return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" onclick="return Update(' + row.id + ');">Check</button >'
                    }
                }
            },
            {
                "data": "fileId",
                "visible": false
            },
            //{
            //    "data": "file",
            //    "visible": false
            //},
            //{
            //    "data": "position",
            //    "visible": false
            //},
            //{
            //    "data": "reference",
            //    "visible": false
            //},
            {
                "data": "employeeId"
                //"visible": false
            }
            //,
            //{
            //    "data": "skills",
            //    "visible": false
            //}
        ]
    });
});


function Update() {
    var Applicant = new Object();
    Applicant.id = val(row.id);
    Applicant.alreadyCheck = false;
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Admin/UpdateCheck',
        data: Check
    }).then((result) => {
        debugger;
        console.log(result);
        if (result != "GAGAL") {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Updated successfully'
            });
            table.ajax.reload();
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed to update!'
            });
            table.ajax.reload();
        }
    }).catch((error) => {
        console.log(error);
    });
}