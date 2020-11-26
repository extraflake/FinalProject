$(document).ready(function () {
    //debugger;
    $.ajax({
        url: "/Registration/GetNamePosition/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("position");
            for (var i = 0; i < qt.data.length; i++) {

                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});