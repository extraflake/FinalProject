var dateChoosen = sessionStorage.getItem("chosen");
var id = sessionStorage.getItem("scheduleId");
var answer = [];

var countDownDate = new Date(dateChoosen).getTime();
console.log(countDownDate);
var x = setInterval(function () {
    var now = new Date().getTime();
    var distance = countDownDate - now;
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    document.getElementById("demo").innerHTML = days + "d " + hours + "h "
        + minutes + "m " + seconds + "s ";

    if (days == 0 && hours == 0 && minutes == 0 && seconds == 0) {
        createDuration();
    }
}, 1000);

function createDuration() {
    var Duration = new Object();
    Duration.ApplicantId = sessionStorage.getItem("applicantId");
    Duration.ScheduleId = id;
    var date = new Date(dateChoosen);
    var y = date.getFullYear();
    var m = date.getMonth();
    var d = date.getDate();
    var h = date.getHours();
    var min = date.getMinutes();
    var s = date.getSeconds();
    var newDate = new Date(y, m, d, h, min, s);
    Duration.StartTime = newDate.toISOString();
    debugger;
    $.ajax({
        type: "POST",
        url: '/Duration/CreateDuration',
        data: Duration
    }).then((result) => {
        console.log(result);
        sessionStorage.setItem("score", 0);
        window.sessionStorage.setItem("question", "");
        window.sessionStorage.setItem("answer", answer);
        createExamDetail();
    }).catch((error) => {
        console.log(error);
    });
}

function createExamDetail() {
    var ExamDetailVM = new Object();
    ExamDetailVM.ApplicantId = sessionStorage.getItem("applicantId");
    debugger;
    $.ajax({
        type: "POST",
        url: '/ExamDetail/CreateExamDetail',
        data: ExamDetailVM
    }).then((result) => {

        debugger;
        console.log(result);
        var examDetailVM = JSON.parse(result);
        sessionStorage.setItem("durationId", examDetailVM['durationId']);
        sessionStorage.setItem("examDetailId", examDetailVM['id']);
        console.log(sessionStorage.getItem("examDetailId"));
        window.location = "/exam/ujian";
    }).catch((error) => {
        console.log(error);
    });

}