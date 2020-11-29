﻿
//$(document).ready(function () {
//    console.log("ready!");
//    $.ajax({
//        "type": "GET",
//        "url": "/DataMaster/GetRole",
//        "contentType": "application/json; charset=utf-8",
//        "dataType": "json",
//        "success": function (data) {
//            qt = JSON.parse(data);
//            qt = qt.data
//            console.log(qt);
//            $('#tablerole').DataTable({
//                data: qt,
//                columns: [
//                    {
//                        render: function (data, type, row, meta) {
//                            return meta.row + meta.settings._iDisplayStart + 1;
//                        }
//                    },
//                    {
//                        "data": "id",
//                        "visible": false
//                    },
//                    { "data": "name" },

//                    {
//                        //"data":"id",
//                        "render": function (data, type, row) {
//                            return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetByIdRole(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
//                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteRole(' + row.id + ');"><i class="fa fa-trash"></i></button>'
//                        }
//                    }]
//            });
//        }
//    });
//});



var table = null;
var qt;

$(document).ready(function () {
    table = $('#tableapplication').DataTable({
        "processing": true,
        "serverside": true,
        "filter": true,
        //"orderMulti": false,
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],

        "ajax": {
            "url": "/DataMaster/GetApplication",
            "type": "GET",
            "datatype": "json",
        },
        //"dataSrc": "data",
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
                //"data":"id",
                "render": function (data, type, row) {
                    console.log(row.id);
                    return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetByIdApplication(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteApplication(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                }
            }]
    });

});



function Save() {
    var univ = new Object();
    univ.Id = $('#Id').val();
    univ.Name = $('#application').val();
    debugger;
    $.ajax({
        type: "Post",
        url: '/DataMaster/AddApplication',
        data: univ
    }).then((result) => {
        debugger;
        console.log(result);
        if (result != "GAGAL") {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Added Successfully'
            });
            table.ajax.reload();
            //window.location = result.url;
        }
        else {
            Swal.fire({
                position: 'center',
                type: 'error',
                icon: 'error',
                title: 'Failed to add!'
            });
        }
    }).catch((error) => {
        console.log(error);
    });
}

function DeleteApplication(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this data!",
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: "Don't Delete",
    }).then((resultt) => {
        if (resultt.isConfirmed) {
            debugger;
            var ind = id;
            $.ajax({
                type: "DELETE",
                url: '/DataMaster/DeleteApplication',
                data: { Id: id }
            }).then((result) => {
                debugger;
                console.log(result);
                if (result != "GAGAL") {
                    Swal.fire({
                        position: 'center',
                        type: 'success',
                        icon: 'success',
                        title: 'Delete successfully!'
                    });
                    table.ajax.reload();
                    //window.location = result.url;
                }
                else {
                    Swal.fire({
                        position: 'center',
                        type: 'error',
                        icon: 'error',
                        title: 'Failed to delete!'
                    });
                }
            }).catch((error) => {
                console.log(error);
            });
        } else if (resultt.isDenied) {
            Swal.fire('Changes are not saved', '', 'info')
        }
    });
}

function UpdateApplication() {
    var role = new Object();
    role.Id = $("#Id").val();
    role.Name = $('#application').val();

    debugger;
    $.ajax({
        type: "PUT",
        url: '/DataMaster/UpdateApplication',
        data: role
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
        }
    }).catch((error) => {
        console.log(error);
    });
}


function GetByIdApplication(id) {
    debugger;
    $.ajax({
        url: "/DataMaster/GetByIdApplication/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: { Id: id },
        async: false,
        success: function (result) {
            debugger;
            if (result != "GAGAL") {
                const obj = JSON.parse(result);
                console.log(obj);
                $('#Id').val(obj.data['id']);
                $('#application').val(obj.data['name']);
                $('#myModal').modal();
                $('#updateBtn').show();
                $('#saveBtn').hide();
            }
            else {
                console.log(result);
            }

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    $('#updateBtn').hide();
    $('#saveBtn').show();
    $('#application').val('');
}