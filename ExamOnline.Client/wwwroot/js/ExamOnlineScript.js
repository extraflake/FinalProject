var num = 1;
var qt;

function Choose() {
    window.location = "exam/ujian"
}

//window.console.log = function () {
//    console.error("Sepertinya anda mengerti cara ngoding!");
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
            console.log(window.sessionStorage.getItem("question"));
            console.log(qt);
            var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
            console.log(qt.length);
            listChoices = shuffle(listChoices);
            //document.getElementById('segmentName').innerHTML = qt[num - 1]['title']
            document.getElementById("question").innerHTML = qt[num - 1]['quest'];
            document.getElementById('segmentName').innerHTML = qt[num - 1]['title'];
            document.getElementById('segmentDuration').innerHTML = "Duration          : " + qt[num - 1]['duration'] + " minutes";
            document.getElementById('questionQuantity').innerHTML = "Question Quantity : " + qt[num - 1]['questionQuantity'];
            document.getElementById("choiceATxt").innerHTML = listChoices[0];
            document.getElementById("choiceBTxt").innerHTML = listChoices[1];
            document.getElementById("choiceCTxt").innerHTML = listChoices[2];
            document.getElementById("choiceDTxt").innerHTML = listChoices[3];
            var div = document.getElementById('btnNav');

            for (var i = 0; i < qt.length; i++) {
                div.innerHTML = div.innerHTML +
                    '<button class="btn btn-light btn-sm mt-1 ml-2" value="' + i + '" onclick="return NavigateToQuestion(' + i + ');">' + (i+1) + '</button>';
            }
            
        }
    })
});

function nextQuestion() {
    console.log(getRadioCheckedValue("choices"));
    num++;
    if (num == 1) {
        $('#prevBtn').hide();
    }
    else if (num > 1) {
        $('#prevBtn').show();
    }
    console.log(num);
    document.getElementById('number').innerHTML = num;
    $(document).ready(function () {
        console.log("ready!");
        var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
        console.log(listChoices);
        listChoices = shuffle(listChoices);
        //document.getElementById('segmentName').innerHTML = qt[num - 1]['title']
        document.getElementById("question").innerHTML = qt[num - 1]['quest'];
        document.getElementById("choiceATxt").innerHTML = listChoices[0];
        document.getElementById("choiceBTxt").innerHTML = listChoices[1];
        document.getElementById("choiceCTxt").innerHTML = listChoices[2];
        document.getElementById("choiceDTxt").innerHTML = listChoices[3];

        
    });
}

function previousQuestion() {
    num--;
    if (num == 1) {
        $('#prevBtn').hide();
    }
    else if (num > 1) {
        $('#prevBtn').show();
    }
    document.getElementById('number').innerHTML = num;
    $(document).ready(function () {
        console.log("ready!");
        var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
        document.getElementById("question").innerHTML = qt[num - 1]['quest'];
        document.getElementById("choiceATxt").innerHTML = listChoices[0];
        document.getElementById("choiceBTxt").innerHTML = listChoices[1];
        document.getElementById("choiceCTxt").innerHTML = listChoices[2];
        document.getElementById("choiceDTxt").innerHTML = listChoices[3];
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
            alert(radios[i].value);
            break;
        }
    }
}

function NavigateToQuestion(number) {
    if (number == 0) {
        $('#prevBtn').hide();
    }
    else if (number > 0) {
        $('#prevBtn').show();
    }
    document.getElementById('number').innerHTML = number+1;
    $(document).ready(function () {
        console.log("ready!");
        var listChoices = [qt[number]['answerA'], qt[number]['answerB'], qt[number]['answerC'], qt[number]['answerD']];
        document.getElementById("question").innerHTML = qt[number]['quest'];
        document.getElementById("choiceATxt").innerHTML = listChoices[0];
        document.getElementById("choiceBTxt").innerHTML = listChoices[1];
        document.getElementById("choiceCTxt").innerHTML = listChoices[2];
        document.getElementById("choiceDTxt").innerHTML = listChoices[3];
    });
}