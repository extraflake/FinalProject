﻿var table = null;
$(document).ready(function () {
    console.log("Bisa masuk!");
    table = $('#table1').DataTable({
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "ajax": {
            "url": "/Admin/GetPosition",
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
                    return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return Delete(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                }
            }]
    });
});


function Save() {
    debugger;
    var Position = new Object();
    Position.Name = $('#Name').val();
    if (Position.Name == '') {
        Swal.fire('Error', 'Please Input Position Name', 'error');
        ClearScreen();
    } else {
        $.ajax({
            type: 'POST',
            url: '/Admin/AddPosition',
            data: Position
        }).then((result) => {
            debugger;
            if (result != "GAGAL") {
                Swal.fire({
                    position: 'center',
                    type: 'success',
                    icon: 'success',
                    title: 'Position Added Successfully'
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
        url: "/Admin/GetByIdPosition/" + Id,
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (result) {
            const obj = JSON.parse(result);
            $('#Id').val(obj.data['id']);
            $('#Name').val(obj.data['name']);
            $('#myModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Update() {
    var Position = new Object();
    Position.Id = $("#Id").val();
    Position.Name = $('#Name').val();
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Admin/UpdatePosition',
        data: Position
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
                url: "/Admin/DeletePosition/",
                data: { Id: Id },
                type: "DELETE",
            }).then((result) => {
                debugger;
                if (result != "GAGAL") {
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