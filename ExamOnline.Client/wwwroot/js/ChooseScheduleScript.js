$(document).ready(function () {

    var dropdown = document.getElementById('examTime');
    $.ajax({
        "type": "GET",
        "url": "/Schedule/LoadSchedules",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            var objSchedule = JSON.parse(data);
            debugger;
            var now = new Date().getTime();
            var scheduleTime = new Date();
            var distance;

            for (var i = 0; i < objSchedule.data.length; i++) {
                scheduleTime = new Date(objSchedule.data[i]['scheduleTime']).getTime();
                distance = scheduleTime - now;
                if (distance < 0) {
                    UpdateSchedule(objSchedule.data[i]['id'], objSchedule.data[i]['scheduleTime']);
                }
                else {
                    if (objSchedule.data[i]["isActive"] == true) {
                        var scheduleDatetime = new Date(objSchedule.data[i]['scheduleTime']).toUTCString();
                        dropdown.innerHTML = dropdown.innerHTML +
                            '<option value="' + objSchedule.data[i]['id'] + '">' + scheduleDatetime + '</option>';
                    }
                }
            }
        }
    });
    GetSegment();
})

function Choose() {
    var dropdownn = document.getElementById("examTime");
    var id = dropdownn.value;
    var text = dropdownn.options[dropdownn.selectedIndex].text;
    sessionStorage.setItem("chosen", text);
    sessionStorage.setItem("id", id);
    //debugger;
    window.location = "/exam/waiting"
}

function GetSegment() {
    $.ajax({
        "type": "GET",
        "url": "/Segment/LoadSegment",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            debugger;
            sessionStorage.setItem("segments", data);
            sessionStorage.setItem("curSegment", 0);
            console.log(sessionStorage.getItem("segments"));
        }
    });
}

function UpdateSchedule(id,scheduleDate) {
    var Schedule = new Object();
    Schedule.Id = id;
    Schedule.scheduleTime = scheduleDate;
    Schedule.isActive = false;
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Schedule/UpdateSchedule',
        data: Schedule
    }).then((result) => {
        console.log(result);
    }).catch((error) => {
    });
    return "";
}