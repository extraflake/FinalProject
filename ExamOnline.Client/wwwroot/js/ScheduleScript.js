$(document).ready(function () {
    console.log("ready!");
    $.ajax({
        "type": "GET",
        "url": "/Schedule/LoadSchedules",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            qt = qt.data
            console.log(qt);
            $('#tableSegment').DataTable({
                data: qt,
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
                    { "data": "scheduleTime" },
                    {
                        "render": function (data, type, row) {
                            return '<button class="btn pull-left hidden-sm-down btn-primary" data-placement="right" data-toggle="tooltip" title = "Edit" onclick="return GetById(' + row.id + ');"><i data-feather="edit"></i></button >' + '&nbsp;' +
                                '<button class="btn btn-danger" data-placement="right" data-toggle="tooltip" data-animation="false" title="Delete" onclick="return DeleteSchedule(' + row.id + ');"><i data-feather="trash-2"></i></button>'
                        }
                    }]
            });
        }
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
    var Schedule = new Object();
    var date = new Date(document.getElementById('date').value);
    var time = document.getElementById('time').value;
    var y = date.getFullYear();
    var m = date.getMonth();
    var d = date.getDate();
    var h = time.substring(0,2);
    var min = time.substring(3,5);
    var scheduleDatetime = new Date(y, m, d,h,min);
    Schedule.scheduleTime = scheduleDatetime.toISOString();
    console.log(Schedule.scheduleTime);
    $.ajax({
        type: "Post",
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
                type: "DELETE",
                url: '/Schedule/DeleteSchedule',
                data: { Id: id }
            }).then((result) => {
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
