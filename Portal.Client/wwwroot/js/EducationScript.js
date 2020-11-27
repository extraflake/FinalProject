$(document).ready(function () {
    //debugger;

    var degree = null;
    var graduateYear = null;

    var d = new Date();
    var year = d.getFullYear();

    var gradYear = document.getElementById("gradyear");
    for (var i = 0; i < 8; i++) {

        var yearOpt = year - 4 + i;

        gradYear.innerHTML = gradYear.innerHTML +
            '<option value="' + yearOpt + '" id="' + yearOpt + '">' + yearOpt + '</option>';
    }

    $.ajax({
        url: "/Registration/GetNameUniversity/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            //console.log(qt);
            var dropDown = document.getElementById("university");
            for (var i = 0; i < qt.data.length; i++) {

                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '" id="' + qt.data[i]['name'] + '">' + qt.data[i]['name'] + '</option>';
            }
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    $.ajax({
        url: "/Registration/GetNameDepartment/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            //console.log(qt);
            var department = document.getElementById("department");
            for (var i = 0; i < qt.data.length; i++) {
                department.innerHTML = department.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '" id="' + qt.data[i]['name'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

});