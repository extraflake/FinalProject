var num = 1;
var qt;
var answer = [];
var isDoubt = [];
var totalQuestion = 0;
var notify = false;
var change = false;
var now = new Date();
var segments = JSON.parse(sessionStorage.getItem("segments"));
var curSegments = sessionStorage.getItem("curSegment");
console.log(curSegments);
console.log(segments[curSegments]);
Date.prototype.addMins = function (min) {
    this.setTime(this.getTime() + (min * 60 * 1000));
    return this;
}

var limit = new Date();
limit.addMins(segments[curSegments]['duration']);

var x = setInterval(function () {
    now = new Date();
    var distance = limit - now;
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

    document.getElementById("remainingTime").innerHTML = "Remaining time : " + minutes + "m " + seconds + "s ";
    if (distance < 0) {
        clearInterval(x);
    }
    if (minutes == 19) {
        $("#badge").show();
        $('#notifIcon').show();
        document.getElementById("notifTitle").innerHTML = "Hurry Up!";
        document.getElementById("notifText").innerHTML = "Your remaining time is running out!";
        //$('#notif').fadeIn('slow', function () {
        //    $('#notif').delay(5000).fadeOut();
        //});
    }
}, 1000);

//window.console.log = function () {
//    console.error("sepertinya anda mengerti cara ngoding!");
//    window.console.log = function () {
//        return false;
//    }
//}

$(document).ready(function () {
    $('#badge').hide();
    $('#notifIcon').hide();

    if (num == 1) {
        $('#prevBtn').hide();
    }
    else if (num > 1) {
        $('#prevBtn').show();
    }
    document.getElementById('number').innerHTML = num;
    debugger;
    var QuestionVM = new Object();
    QuestionVM.SegmentId = segments[curSegments]['id'];
    $.ajax({
        type: "GET",
        url: "/Exam/LoadQuestion",
        contentType: "application/json; charset=utf-8",
        data: QuestionVM,
        dataType: "json",
        success: function (data) {
            debugger;
            if (window.sessionStorage.getItem("question") == "") {
                window.sessionStorage.setItem("question", data);
            }
            qt = JSON.parse(window.sessionStorage.getItem("question"));
            console.log(qt);

            window.sessionStorage.setItem("questionSave", JSON.stringify(qt));

            var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
            //console.log(qt.length);
            console.log(sessionStorage.getItem("listShuffled" + num));
            console.log(num);
            if (window.sessionStorage.getItem("listShuffled" + num) == null) {
                listChoices = shuffle(listChoices);
                window.sessionStorage.setItem("listShuffled" + num, JSON.stringify(listChoices));
            } else {
                listChoices = JSON.parse(window.sessionStorage.getItem("listShuffled" + num));
            }
            console.log(listChoices);
            document.getElementById("question").innerHTML = qt[num - 1]['quest'];
            document.getElementById('segmentName').innerHTML = qt[num - 1]['title'];
            document.getElementById('segmentDuration').innerHTML = "Duration          : " + qt[num - 1]['duration'] + " minutes";
            document.getElementById('questionQuantity').innerHTML = "Question Quantity : " + qt[num - 1]['questionQuantity'];
            totalQuestion = qt[num - 1]['questionQuantity'];
            document.getElementById("answerA").innerHTML = listChoices[0];
            document.getElementById("answerB").innerHTML = listChoices[1];
            document.getElementById("answerC").innerHTML = listChoices[2];
            document.getElementById("answerD").innerHTML = listChoices[3];
            var div = document.getElementById('btnNav');

            if (sessionStorage.getItem("answer") == "") {
                intialAnswer();
            }

            for (var i = 0; i < qt.length; i++) {
                div.innerHTML = div.innerHTML +
                    '<button class="btn btn-light btn-sm mt-1 ml-2" value="' + i + '" id="' + i + '" onclick="return NavigateToQuestion(' + i + ');">' + (i + 1) + '</button>';
            }
        }
    })
});

function nextQuestion() {
    if (num == totalQuestion) {
        answer[num - 1] = getRadioCheckedValue("choices");
        document.getElementById(num - 1).className = 'btn btn-primary ml-2';
        setRadioCheckedValue("choices");
        console.log(answer);
        finishSegment();
    }
    else {
        answer[num - 1] = getRadioCheckedValue("choices");
        if (change) {
            document.getElementById(num - 1).className = 'btn btn-warning ml-2';

        }
        else {
            document.getElementById(num - 1).className = 'btn btn-primary ml-2';
        }
        change = false;


        num++;
        isFinalQuestion(num);
        console.log(answer);
        setRadioCheckedValue("choices");
        isNotFirstQuestion(num);

        $(document).ready(function () {
            debugger;
            document.getElementById('number').innerHTML = num;
            var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
            console.log(window.sessionStorage.getItem("listShuffled" + num));
            console.log(num);
            if (window.sessionStorage.getItem("listShuffled" + num) == null) {
                listChoices = shuffle(listChoices);
                window.sessionStorage.setItem("listShuffled" + num, JSON.stringify(listChoices));
            } else {
                listChoices = JSON.parse(window.sessionStorage.getItem("listShuffled" + num));
            }
            document.getElementById("question").innerHTML = qt[num - 1]['quest'];
            document.getElementById("answerA").innerHTML = listChoices[0];
            document.getElementById("answerB").innerHTML = listChoices[1];
            document.getElementById("answerC").innerHTML = listChoices[2];
            document.getElementById("answerD").innerHTML = listChoices[3];
        });
    }
}

function previousQuestion() {
    num--;
    isNotFirstQuestion(num);
    isFinalQuestion(num);
    document.getElementById('number').innerHTML = num;
    $(document).ready(function () {
        var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
        if (window.sessionStorage.getItem("listShuffled" + num) == null) {
            listChoices = shuffle(listChoices);
            window.sessionStorage.setItem("listShuffled" + num, JSON.stringify(listChoices));
        } else {
            listChoices = JSON.parse(window.sessionStorage.getItem("listShuffled" + num));
        }
        document.getElementById("question").innerHTML = qt[num - 1]['quest'];
        document.getElementById("answerA").innerHTML = listChoices[0];
        document.getElementById("answerB").innerHTML = listChoices[1];
        document.getElementById("answerC").innerHTML = listChoices[2];
        document.getElementById("answerD").innerHTML = listChoices[3];
        var radios = document.getElementsByName("choices");
        for (var i = 0; i < listChoices.length; i++) {
            if (listChoices[i] == answer[num - 1]) {
                radios[i].checked = true;
            }
        }
    });
}

function shuffle(array) {
    var currentIndex = array.length, temporaryValue, randomIndex;
    while (0 !== currentIndex) {
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex -= 1;
        temporaryValue = array[currentIndex];
        array[currentIndex] = array[randomIndex];
        array[randomIndex] = temporaryValue;
    }

    return array;
}

function getRadioCheckedValue(radio_name) {
    var radios = document.getElementsByName(radio_name);
    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked) {
            var radVal = radios[i].value;
            return document.getElementById(radVal).innerHTML;
        }
    }

    for (var i = 0, length = radios.length; i < length; i++) {
        if (radios[i].checked == false) {
            return "";
        }
    }
}

function NavigateToQuestion(number) {
    num = number + 1;
    isNotFirstQuestion((number + 1));
    isFinalQuestion(number + 1);
    document.getElementById('number').innerHTML = number + 1;
    $(document).ready(function () {
        var listChoices = [qt[number]['answerA'], qt[number]['answerB'], qt[number]['answerC'], qt[number]['answerD']];
        if (window.sessionStorage.getItem("listShuffled" + num) == null) {
            listChoices = shuffle(listChoices);
            window.sessionStorage.setItem("listShuffled" + num, JSON.stringify(listChoices));
        } else {
            listChoices = JSON.parse(window.sessionStorage.getItem("listShuffled" + num));
        }
        document.getElementById("question").innerHTML = qt[number]['quest'];
        document.getElementById("answerA").innerHTML = listChoices[0];
        document.getElementById("answerB").innerHTML = listChoices[1];
        document.getElementById("answerC").innerHTML = listChoices[2];
        document.getElementById("answerD").innerHTML = listChoices[3];
        var radios = document.getElementsByName("choices");
        for (var i = 0; i < listChoices.length; i++) {
            if (listChoices[i] == answer[number]) {
                radios[i].checked = true;
            }
        }
    });
}

function setRadioCheckedValue(radio_name) {
    var radios = document.getElementsByName(radio_name);
    for (var i = 0, length = radios.length; i < length; i++) {
        radios[i].checked = false;
    }
}

function doubtFull() {
    change = true;
    document.getElementById(num - 1).className = 'btn btn-warning ml-2';
    isDoubt[num - 1] = true;
    nextQuestion();
}

function isFinalQuestion(number) {
    if (number < totalQuestion) {
        document.getElementById('nextBtn').innerHTML = 'Next<i class="fa fa-arrow-right"></i>';
        return false;
    }
    else if (number == totalQuestion) {
        document.getElementById('nextBtn').innerHTML = 'Submit my Answer<i class="fa fa-arrow-right"></i>';
        return true;
    }
    return "";
}

function isNotFirstQuestion(number) {
    if (number == 1) {
        $('#prevBtn').hide();
        return false;
    }
    else if (number > 1) {
        $('#prevBtn').show();
        return true;
    }
    return "";
}

function intialAnswer() {
    for (var i = 0; i < totalQuestion; i++) {
        answer[i] = "";
        isDoubt[i] = false;
    }
    return "";
}

function finishSegment() {
    if (curSegments < segments.length-1) {
        curSegments++;
        sessionStorage.setItem("question", '');
        sessionStorage.setItem("curSegment", curSegments);
        for (var i = 0; i <= num; i++) {
            window.sessionStorage.removeItem("listShuffled" + i);
        }
        var score = parseInt(sessionStorage.getItem("score"));
        for (var i = 0; i < answer.length; i++) {
            console.log(answer[i]);
            console.log(qt[i]['correctAnswer']);
            if (answer[i] == qt[i]['correctAnswer']) {
                score += qt[i]['point'];
            }
        }
        sessionStorage.setItem("score", score);
        location.reload();
    }
    else if (curSegments == segments.length - 1) {
        var score = parseInt(sessionStorage.getItem("score"));
        for (var i = 0; i < answer.length; i++) {
            if (answer[i] == qt[i]['correctAnswer']) {
                score += qt[i]['point'];
            }
        }
        sessionStorage.setItem("score", score);
        updateDuration();
        updateExamDetail();
        Swal.fire({
            position: 'center',
            type: 'info',
            icon: 'info',
            title: 'Your final score : ' + sessionStorage.getItem("score")
        });
    }
}

function updateDuration() {
    var ExamDetailVM = new Object();
    ExamDetailVM.DurationId = parseInt(sessionStorage.getItem("durationId"));
    var date = new Date();
    var y = date.getFullYear();
    var m = date.getMonth();
    var d = date.getDate();
    var h = date.getHours();
    var min = date.getMinutes();
    var s = date.getSeconds();
    var newDate = new Date(y, m, d, h, min, s);
    ExamDetailVM.EndTime = newDate.toISOString(); 
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Duration/UpdateDuration',
        data: ExamDetailVM
    }).then((result) => {
        debugger;
        console.log(result);
        if (result != "GAGAL") {
            return;
        }
        else {
        }
    }).catch((error) => {
        console.log(error);
    });
}

function updateExamDetail() {
    var ExamDetailVM = new Object();
    ExamDetailVM.FinalScore = parseInt(sessionStorage.getItem("score"));
    ExamDetailVM.Id = parseInt(sessionStorage.getItem("examDetailId"));
    debugger;
    $.ajax({
        type: "PUT",
        url: '/ExamDetail/UpdateExamDetail',
        data: ExamDetailVM
    }).then((result) => {
        return;
    }).catch((error) => {
    });
}