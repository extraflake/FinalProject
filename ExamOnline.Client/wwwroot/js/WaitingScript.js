var dateChoosen = localStorage.getItem("chosen");
var id = localStorage.getItem("id");

var countDownDate = new Date(dateChoosen).getTime();
console.log(countDownDate);
var x = setInterval(function() {
    var now = new Date().getTime();
    var distance = countDownDate - now;
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);

  document.getElementById("demo").innerHTML = days + "d " + hours + "h "
  + minutes + "m " + seconds + "s ";

    if (distance < 0) {
        clearInterval(x);
        window.sessionStorage.setItem("question", "");
        window.location = "/exam/ujian";
    }
}, 1000);

