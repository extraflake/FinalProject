var num = 1;
var qt;

function Choose() {
    window.location = "exam/ujian"
}

$(document).ready(function () {
    document.getElementById('number').innerHTML = num;
    console.log("ready!");
    debugger;
    $.ajax({
        type: "GET",
        url: "/Exam/LoadQuestion",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            qt = JSON.parse(data);
            var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
            //console.log(listChoices);
            listChoices = shuffle(listChoices);
            //document.getElementById('segmentName').innerHTML = qt[num - 1]['title']
            document.getElementById("question").innerHTML = qt[num - 1]['quest'];
            document.getElementById("choiceATxt").innerHTML = listChoices[0];
            document.getElementById("choiceBTxt").innerHTML = listChoices[1];
            document.getElementById("choiceCTxt").innerHTML = listChoices[2];
            document.getElementById("choiceDTxt").innerHTML = listChoices[3];
        }
    })
});

function nextQuestion() {
    num++;
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

//function previousQuestion() {
//    num--;
//    if (num == 0) {
//        document.getElementById("prevBtn").disabled = true;
//    }
//    else if (num >0){
//        document.getElementById("prevBtn").disabled = false;
//    }
//    console.log(num);
//    document.getElementById('number').innerHTML = num;
//    $(document).ready(function () {
//        console.log("ready!");
//        var listChoices = [qt[num - 1]['answerA'], qt[num - 1]['answerB'], qt[num - 1]['answerC'], qt[num - 1]['answerD']];
//        //console.log(listChoices);
//        listChoices = shuffle(listChoices);
//        //document.getElementById('segmentName').innerHTML = qt[num - 1]['title']
//        document.getElementById("question").innerHTML = qt[num - 1]['quest'];
//        document.getElementById("choiceATxt").innerHTML = listChoices[0];
//        document.getElementById("choiceBTxt").innerHTML = listChoices[1];
//        document.getElementById("choiceCTxt").innerHTML = listChoices[2];
//        document.getElementById("choiceDTxt").innerHTML = listChoices[3];
//    });
//}

function shuffle(array) {
    var currentIndex = array.length, temporaryValue, randomIndex;

    // While there remain elements to shuffle...
    while (0 !== currentIndex) {

        // Pick a remaining element...
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex -= 1;

        // And swap it with the current element.
        temporaryValue = array[currentIndex];
        array[currentIndex] = array[randomIndex];
        array[randomIndex] = temporaryValue;
    }

    return array;
}