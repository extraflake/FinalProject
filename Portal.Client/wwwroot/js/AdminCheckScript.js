var EditProfileVM = new Object();
var table = null;
var firstname, lastname;
var fullname = "";

//function LoadEmployee(datarender) {
//    return $.ajax({
//            type: "Get",
//            url: '/Admin/GetEmployeeData',
//            data: datarender,
//            success: function (response) {
//                //debugger;
//                var qt = JSON.parse(response.data);
//                //console.log(qt.data['firstName']);
//                firstname = qt.data['firstName'];
//                //console.log(firstname);
//                resolve = firstname;
//                console.log(resolve);
//                return resolve;
//            }
//        });
//}

$(document).ready(function () {

    table = $('#table1').DataTable({
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "deferRender": true,
        "ajax": {
            "url": "/Admin/GetApplicant",
            "type": "GET",
            "datatype": "json"
        },
        "datasrc": "",
        //"columnDefs": [{
        //    "render": async function (data, type, row) {
        //        debugger;
        //        //console.log(data);
        //        console.log(type);
        //        if (type === 'type') {
        //            //debugger;
        //            EditProfileVM.EmployeeId = data;
        //            //console.log(data);
        //            //EditProfileVM.EmployeeId = data;
        //            var dataProfile = LoadEmployee(EditProfileVM);
        //            console.log(dataProfile);
        //            return '<span>' + dataProfile  + '</span>';
        //        }
        //        else {
        //            return '<span>' + "Data Tidak Masuk" + '<span>';
        //        }
        //    },
        //    "targets": 4
        //}],
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
                    //debugger;
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
            {
                "data": "firstName"
                //"visible": false
            }

        ]
    });

});



function Update(id) {
    debugger;
    var ApplicantVM = new Object();
    ApplicantVM. id = id;
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