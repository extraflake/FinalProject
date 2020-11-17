var num = 0;

function Choose() {
    window.location = "exam/ujian"
}

$(document).ready(function () {
    if (num == 0) {
        document.getElementById("prevBtn").disabled = true;
    }
    else if (num > 0){
        document.getElementById("prevBtn").disabled = false;
    }
    console.log("ready!");
    $.ajax({
        type: "GET",
        url: "/Exam/LoadQuestion",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            var qt = JSON.parse(data);
            //console.log(qt);
            document.getElementById("question").innerHTML = qt.data[num].quest;
            document.getElementById("choiceATxt").innerHTML = qt.data[num].answerA;
            document.getElementById("choiceBTxt").innerHTML = qt.data[num].answerB;
            document.getElementById("choiceCTxt").innerHTML = qt.data[num].answerC;
            document.getElementById("choiceDTxt").innerHTML = qt.data[num].answerD;
        }
    })
});

function nextQuestion() {
    if (num == 0) {
        document.getElementById("prevBtn").disabled = true;
    }
    else if (num > 0){
        document.getElementById("prevBtn").disabled = false;
    }
    num++;
    console.log(num);
    $(document).ready(function () {
        console.log("ready!");
        $.ajax({
            type: "GET",
            url: "/Exam/LoadQuestion",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var qt = JSON.parse(data);
                //console.log(qt);
                document.getElementById("question").innerHTML = qt.data[num].quest;
                document.getElementById("choiceATxt").innerHTML = qt.data[num].answerA;
                document.getElementById("choiceBTxt").innerHTML = qt.data[num].answerB;
                document.getElementById("choiceCTxt").innerHTML = qt.data[num].answerC;
                document.getElementById("choiceDTxt").innerHTML = qt.data[num].answerD;
            }
        })
    });
}

function previousQuestion() {
    if (num == 0) {
        document.getElementById("prevBtn").disabled = true;
    }
    else if (num >0){
        document.getElementById("prevBtn").disabled = false;
    }
    num--;
    console.log(num);
    $(document).ready(function () {
        console.log("ready!");
        $.ajax({
            type: "GET",
            url: "/Exam/LoadQuestion",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var qt = JSON.parse(data);
                //console.log(qt);
                document.getElementById("question").innerHTML = qt.data[num].quest;
                document.getElementById("choiceATxt").innerHTML = qt.data[num].answerA;
                document.getElementById("choiceBTxt").innerHTML = qt.data[num].answerB;
                document.getElementById("choiceCTxt").innerHTML = qt.data[num].answerC;
                document.getElementById("choiceDTxt").innerHTML = qt.data[num].answerD;
            }
        })
    });
}