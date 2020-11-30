var scheduleId;
var table = null;
$(document).ready(function () {
    console.log("ready!");
    table = $('#tableSchedule').DataTable({
        "processing": true,
        "serverside": true,
        "filter": true,
        //"orderMulti": false,
        "lengthMenu": [[10, 25, 50, 100], [10, 25, 50, 100]],
        "ajax": {
            "url": "/Schedule/LoadSchedules",
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
            {
                "data": "scheduleTime"
            },
            {
                "data": "isActive",

            },
            {
                "render": function (data, type, row) {
                    return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i class="fa fa-edit"></i></button >' + '&nbsp;' +
                        '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteSchedule(' + row.id + ');"><i class="fa fa-trash"></i></button>'
                }
            }]
    });
});


function Add() {
    $('#updateBtn').hide();
    $('#saveBtn').show();
    $('#date').val('');
    $('#time').val('');
    $('#status').val('');
}

function Save() {
    var Schedule = new Object();
    var date = new Date(document.getElementById('date').value);
    var time = document.getElementById('time').value;
    var y = date.getFullYear();
    var m = date.getMonth();
    var d = date.getDate();
    var h = time.substring(0, 2);
    console.log(h);
    var min = time.substring(3, 5);
    var scheduleDatetime = new Date(y, m, d, h, min);
    Schedule.scheduleTime = scheduleDatetime.toLocaleString();
    var status = document.getElementById('status');
    Schedule.isActive = (status == (status));
    $.ajax({
        type: "POST",
        url: '/schedule/addschedule',
        data: Schedule
    }).then((result) => {
        if (result != "GAGAL") {
            Swal.fire({
                position: 'center',
                type: 'success',
                icon: 'success',
                title: 'Added Successfully'
            });
            table.ajax.reload();
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

function DeleteSchedule(id) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this data!",
        showDenyButton: true,
        confirmButtonText: 'Delete',
        denyButtonText: "Don't Delete",
    }).then((resultt) => {
        if (resultt.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/Schedule/DeleteSchedule',
                data: { Id: id }
            }).then((result) => {
                debugger;
                if (result != "GAGAL") {
                    Swal.fire({
                        position: 'center',
                        type: 'success',
                        icon: 'success',
                        title: 'Delete successfully!'
                    });
                    table.ajax.reload();
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
    scheduleId = id;
    $.ajax({
        url: "/Schedule/GetById/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        data: { Id: id },
        async: false,
        success: function (result) {
            if (result != "GAGAL") {
                const obj = JSON.parse(result);
                $('#Id').val(obj['id']);

                var date = new Date(obj['scheduleTime']);

                var day = ("0" + date.getDate()).slice(-2);
                var month = ("0" + (date.getMonth() + 1)).slice(-2);

                var today = date.getFullYear() + "-" + (month) + "-" + (day);
                var h = date.getHours();
                var min = date.getMinutes();
                var time = h + ":" + min;
                console.log(time);
                $('#date').val(today);
                $('#time').val(time);
                console.log(obj['isActive']);
                $('#status').val(obj['isActive'].toString());
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

function UpdateSchedule() {
    var Schedule = new Object();
    Schedule.Id = $("#Id").val();
    var date = new Date(document.getElementById('date').value);
    var time = document.getElementById('time').value;
    var y = date.getFullYear();
    var m = date.getMonth();
    var d = date.getDate();
    var h = time.substring(0, 2);
    var min = time.substring(3, 5);
    var scheduleDatetime = new Date(y, m, d, h, min);
    Schedule.scheduleTime = scheduleDatetime.toISOString();
    var status = document.getElementById('status');
    Schedule.isActive = (status == (status));
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Schedule/UpdateSchedule',
        data: Schedule
    }).then((result) => {
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

