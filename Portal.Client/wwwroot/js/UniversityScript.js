$(document).ready(function () {
    //debugger;

    $.ajax({
        url: "/Registration/GetNameUniversity/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("university");
            for (var i = 0; i < qt.data.length; i++) {

                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['name'] + '</option>';
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
            console.log(qt);
            var department = document.getElementById("department");
            for (var i = 0; i < qt.data.length; i++) {

                department.innerHTML = department.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    // Get Education Data
    var educationId = null;
    $.ajax({
        url: "/Registration/GetEmployeeData/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            debugger;
            var qt = JSON.parse(data);
            console.log(qt);
            //console.log(qt);
            educationId = qt.data['education'];
            console.log(educationId);
            //var email = $("#email").val(qt.data['email']);
            //var phone = $("#hp").val(qt.data['phone']);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});