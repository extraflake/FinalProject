var qt;
var table = null;
$(document).ready(function () {
    console.log("ready!");

    debugger;
    $.ajax({
        type: "GET",
        url: "/DataMaster/GetUniversity"
    }).then((result) => {
        debugger;
        qt = result;
    }).catch((error) => {
        console.log(error);
    });

    table = $('#tableuniv').DataTable({
        "processing": true,
        "serverside": true,
        "filter": true,
        //"orderMulti": false,
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],

        "ajax": {
            "url": "/DataMaster/GetUniversity",
            "type": "GET",
            "datatype": "json",
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
            { "data": "name" },

            {
                //"data":"id",
                "render": function (data, type, row, meta) {
                    return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + meta.row + meta.settings._iDisplayStart + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="DeleteUniversity(' + meta.row + meta.settings._iDisplayStart + ');"><i class="fa fa-trash"></i></button>'

                }
            }]
        //+ row.id +
    });

    //$.ajax({
    //    "type": "GET",
    //    "url": "/DataMaster/GetUniversity",
    //    "contentType": "application/json; charset=utf-8",
    //    "dataType": "json",
    //    "success": function (data) {
    //        qt = JSON.parse(data);
    //        qt = qt.data
    //        console.log(qt);
    //        $('#tableuniv').DataTable({
    //            data: qt,
    //            columns: [
    //                {
    //                    render: function (data, type, row, meta) {
    //                        return meta.row + meta.settings._iDisplayStart + 1;
    //                    }
    //                },
    //                {
    //                    "data": "id"
    //                    //"visible": false
    //                },
    //                { "data": "name" },

    //                {
    //                    //"data":"id",
    //                    "render": function (data, type, row, meta) {    
    //                        return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
    //                            '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="DeleteUniversity(' + meta.row + meta.settings._iDisplayStart + ');"><i class="fa fa-trash"></i></button>'

    //                    }
    //                }]
    //        });
    //    }
    //});
});


function Save() {
    debugger;
    var univ = new Object();
    univ.Id = $('#Id').val();
    univ.Name = $('#Name').val();
    debugger;
    $.ajax({
        type: "Post",
        url: '/DataMaster/AddUniversity',
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

function DeleteUniversity(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this data!",
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: "Don't Delete",
    }).then((resultt) => {
        if (resultt.isConfirmed) {
            debugger;
            var ind = qt.data[id / 10]['id'];
            $.ajax({
                type: "DELETE",
                url: '/DataMaster/DeleteUniversity',
                data: { Id: ind }
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

function GetById(id) {
    debugger;
    var ind = qt.data[id / 10]['id'];
    $.ajax({
        url: "/DataMaster/GetById/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: { Id: ind },
        async: false,
        success: function (result) {
            if (result != "GAGAL") {
                const obj = JSON.parse(result);
                console.log(obj);
                $('#Id').val(obj.data['id']);
                $('#Name').val(obj.data['name']);
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

function UpdateUniversity() {
    var univ = new Object();
    univ.Id = $('#Id').val();
    univ.Name = $('#Name').val();
    debugger;
    $.ajax({
        type: "PUT",
        url: '/DataMaster/UpdateUniversity',
        data: univ
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

function Add() {
    $('#updateBtn').hide();
    $('#saveBtn').show();
    $('#Id').val('');
    $('#Name').val('');
}
