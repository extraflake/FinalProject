$(document).ready(function () {
    var dropdown = document.getElementById('examTime');
    $.ajax({
        "type": "GET",
        "url": "/Schedule/LoadSchedules",
        "contentType": "application/json; charset=utf-8",
        "dataType": "json",
        "success": function (data) {
            qt = JSON.parse(data);
            debugger;
            console.log(qt.data);
            for (var i = 0; i < qt.data.length; i++) {
                var scheduleDatetime = new Date(qt.data[i]['scheduleTime']);
                dropdown.innerHTML = dropdown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + scheduleDatetime + '</option>';
            }
        }
    }); 
})

function Choose() {
    var dropdownn = document.getElementById("examTime");
    var id = dropdownn.value;
    var text = dropdownn.options[dropdownn.selectedIndex].text;
    localStorage.setItem("chosen", text);
    localStorage.setItem("id", id);
    //debugger;
    window.location = "/exam/waiting"
}