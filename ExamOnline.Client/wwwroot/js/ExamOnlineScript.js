var num = 1;
var qt;
var answer = [];
var isDoubt = [];
var totalQuestion = 0;

//window.console.log = function () {
//    console.error("sepertinya anda mengerti cara ngoding!");
//    window.console.log = function () {
//        return false;
//    }
//}

$(document).ready(function () {
    if (num == 1) {
        $('#prevBtn').hide();
    }
    else if (num > 1) {
        $('#prevBtn').show();
    }
    document.getElementById('number').innerHTML = num;
    debugger;
    $.ajax({
        type: "GET",
        url: "/Exam/LoadQuestion",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (window.sessionStorage.getItem("question") == "") {
                window.sessionStorage.setItem("question", data);
            }
            qt = JSON.parse(window.sessionStorage.getItem("question"));
            //console.log(window.sessionStorage.getItem("question"));
            console.log(qt);

            window.sessionStorage.setItem("questionSave", JSON.stringify(qt));
            //console.log(window.sessionStorage.setItem("questionSave", qt));

            var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
            //console.log(qt.length);
            if (window.sessionStorage.getItem("listShuffled" + num) == null) {
                listChoices = shuffle(listChoices);
                window.sessionStorage.setItem("listShuffled" + num, JSON.stringify(listChoices));
            } else {
                listChoices = JSON.parse(window.sessionStorage.getItem("listShuffled" + num));
            }
            //console.log(window.sessionStorage.getItem("listShuffled" + num));
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
            intialAnswer();

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
        console.log(answer);
        finishSegment();
    }
    else {
        answer[num - 1] = getRadioCheckedValue("choices");
        if (isDoubt[num - 1] == true && answer[num - 1] != "") {
            document.getElementById(num - 1).className = 'btn btn-warning ml-2';
        }
        else if (isDoubt[num - 1] == false || answer[num - 1] != "") {
            document.getElementById(num - 1).className = 'btn btn-primary ml-2';
        }
        num++;
        isFinalQuestion(num);
        console.log(answer);
        setRadioCheckedValue("choices");
        isNotFirstQuestion(num);

        $(document).ready(function () {
            debugger;
            document.getElementById('number').innerHTML = num;
            //var lq = JSON.parse(window.sessionStorage.getItem("questionSave"));
            //var listChoices = JSON.parse(window.sessionStorage.getItem("listShuffled"));
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
        });
    }
}

function previousQuestion() {
    num--;
    isNotFirstQuestion(num);
    isFinalQuestion(num);
    document.getElementById('number').innerHTML = num;
    $(document).ready(function () {
        //var lq = window.sessionStorage.getItem("questionSave");
        //var listChoices = window.sessionStorage.getItem("listShuffled");
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
        //var lq = window.sessionStorage.getItem("questionSave");
        //var listChoices = window.sessionStorage.getItem("listShuffled");
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
    var score = 0;
    var ExamDetail = new Object();
    ExamDetail.FinalScore = score;
    debugger;
    $.ajax({
        type: "PUT",
        url: '/Exam/UpdateExamDetail',
        data: ExamDetail
    }).then((result) => {
        debugger;
        console.log(ExamDetail);
        for (var i = 0; i < answer.length; i++) {
            console.log(answer[i]);
            console.log(qt[i]['correctAnswer']);
            if (answer[i] == qt[i]['correctAnswer']) {

                score += qt[i]['point'];
            }
        }
        Swal.fire({
            position: 'center',
            type: 'info',
            icon: 'info',
            title: 'Your score : ' + score
        });;
    });
}