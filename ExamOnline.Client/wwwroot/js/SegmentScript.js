﻿var table = null;
var qt;
var data;

$(document).ready(function () {
    console.log("Bisa masuk!");
    table = $('#tableSegment').DataTable({
        "processing": true,
        "serverside": true,
        "filter": true,
        //"orderMulti": false,
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "ajax": {
            "url": "/Segment/LoadSegment",
            "type": "GET",
            "datatype": "json"
        },
        "dataSrc": "data",
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
            { "data": "title" },
            {
                "data": "duration",
                "render": function (data, type, row, meta) {
                    return data + " minutes";
                }
            },
            {
                "data": "questionQuantity",
                "className": "text-center"
            },
            {
                "render": function (data, type, row) {
                    return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteSegment(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                }
            }]
    });
});

function Add() {
    $('#updateBtn').hide();
    $('#saveBtn').show();
    $('#title').val('');
    $('#duration').val('');
    $('#questionQty').val('');
}

function Save() {
    var Segment = new Object();
    Segment.Title = $('#title').val();
    Segment.Duration = $('#duration').val();
    Segment.QuestionQuantity = $('#questionQty').val();
    debugger;
    $.ajax({
        type: "Post",
        url: '/segment/addsegment',
        data: Segment
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

function DeleteSegment(id) {
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
                url: '/Segment/DeleteSegment',
                data: {Id : id}
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
    })
}

function UpdateSegment() {
    var Segment = new Object();
    Segment.Id = $("#Id").val();
    Segment.Title = $('#title').val();
    Segment.Duration = $('#duration').val();
    Segment.QuestionQuantity = $('#questionQty').val();
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Segment/UpdateSegment',
        data: Segment
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

function GetById(id) {
    debugger;
    $.ajax({
        url: "/Segment/GetById/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: {Id : id},
        async: false,
        success: function (result) {
            if (result != "GAGAL") {
                const obj = JSON.parse(result);
                console.log(obj);
                $('#Id').val(obj['id']);
                $('#title').val(obj['title']);
                $('#duration').val(obj['duration']);
                $('#questionQty').val(obj['questionQuantity']);
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





    