$(document).ready(function () {
    debugger;
    $.ajax({
        url: "/Registration/GetUserData/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            console.log(qt);
            //console.log(qt.data['phone']);
            var email = $("#email").val(qt.data['email']);
            var phone = $("#hp").val(qt.data['phone']);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});