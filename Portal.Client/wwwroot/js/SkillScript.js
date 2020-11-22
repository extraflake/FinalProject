$(document).ready(function () {
    //debugger;
    $('#skill').select2();

    $.ajax({
        url: "/Registration/GetNameSkill/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            debugger;
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("skill");
            //var dropDown = $('#skill').select2();
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