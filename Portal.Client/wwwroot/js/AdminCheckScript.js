var table = null;
$(document).ready(function () {
    
    table = $('#table1').DataTable({
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "ajax": {
            "url": "/Admin/GetApplicant",
            "type": "GET",
            "datatype": "json",
            "beforeSend": function () {
                debugger;
                var createLoader = document.getElementById("loader");
                createLoader.classList.remove('hidden');
            },
            "complete": function () {
                var createLoader = document.getElementById("loader");
                createLoader.classList.add('hidden');
            }
        },
        "datasrc": "",
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
                "render": function (data, type, row) {
                    debugger;
                    //console.log(data);
                    if (data == false) {
                        return '<span>Test Complete</span>'
                    }
                    else if (data == true) {
                        return '<button class="btn pull-left hidden-sm-down btn-success" data-placement="right" onclick="return Update(' + row.id + ');">Check</button >'
                    }
                    else {
                        return '<span>Data Not Returned because ' + data + '</span>'
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


function Update(id) {
    debugger;
    var ApplicantVM = new Object();
    ApplicantVM.id = id;
    ApplicantVM.alreadyCheck = false;
    //debugger;
    $.ajax({
        type: "PUT",
        url: '/Admin/UpdateCheck',
        data: ApplicantVM,
        beforeSend: function () {
            debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        }
    }).then((result) => {
        debugger;
        console.log(result);
        if (result != "sukses") {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Updated successfully'
            });
            
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed to update!'
            });
        }
        table.ajax.reload();
    });
}