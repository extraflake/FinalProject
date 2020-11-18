$(document).ready(function () {
    console.log("ready!");
    $.ajax({
        type: "GET",
        url: "/schedule/chooseschedule",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log(data);
        }
    });
});

function Save() {
    //var Schedule = new Object();
    var date = new Date(document.getElementById('date').value);
    var time = document.getElementById('time').value;
    //Schedule.Schedule = $('#title').val();
    var y = date.getFullYear();
    var m = date.getMonth();
    var d = date.getDay();
    var h = time.substring(0,2);
    var min = time.substring(3,5);
    var scheduleDatetime = new Date(y, m, d, h, min, 00, 00);
    console.log(scheduleDatetime);
    //$.ajax({
    //    type: "Post",
    //    url: '/segment/addsegment',
    //    data: Segment
    //}).then((result) => {
    //    debugger;
    //    console.log(result);
    //    if (result != "GAGAL") {
    //        Swal.fire({
    //            position: 'center',
    //            type: 'success',
    //            icon: 'success',
    //            title: 'Added Successfully'
    //        });
    //        //window.location = result.url;
    //    }
    //    else {
    //        Swal.fire({
    //            position: 'center',
    //            type: 'error',
    //            icon: 'error',
    //            title: 'Failed to add!'
    //        });
    //    }
    //}).catch((error) => {
    //    console.log(error);
    //});
}
