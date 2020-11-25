$(document).ready(function () {
    //debugger;
    //User Data
    $.ajax({
        url: "/Registration/GetUserData/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            //console.log(qt);
            var email = $("#email").val(qt.data['email']);
            var phone = $("#hp").val(qt.data['phone']);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    //Employee Data
    $.ajax({
        url: "/Registration/GetEmployeeData/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            //debugger;
            var qt = JSON.parse(data);
            //console.log(qt);
            var first = qt.data['firstName'].charAt(0).toUpperCase() + qt.data['firstName'].slice(1);
            var firstname = $("#firstname").val(first);
            var last = qt.data['lastName'].charAt(0).toUpperCase() + qt.data['lastName'].slice(1);
            var lastname = $("#lastname").val(last);

            var getBirthDate = new Date(qt.data['birthDate']);
            var d = getBirthDate.getDate();
            var m = getBirthDate.getMonth() + 1;
            var y = getBirthDate.getFullYear();
            var dateString = y + '-' + (m <= 9 ? '0' + m : m) + '-' + (d <= 9 ? '0' + d : d);
            //var dateString = (d <= 9 ? '0' + d : d) + '-' + (m <= 9 ? '0' + m : m) + '-' + y;
            var birthdate = $('#birthdate').val(dateString);

            var gender = document.getElementById("gender");
            var genderValue = qt.data['gender'];
            var genderInnerHTML = null;
            if (genderValue == 'Pria') {
                genderInnerHTML = 'L'
            }
            else {
                genderInnerHTML = 'P'
            }
            gender.innerHTML = gender.innerHTML +
                '<option>' + genderInnerHTML + '</option>';


            // Get Religion
            debugger;
            var RegisterVM = new Object();
            RegisterVM.ReligionId = qt.data['religionID'];

            $.ajax({
                type: "Get",
                url: '/Registration/GetReligion',
                data: RegisterVM,
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                async: false,
                success: function (data) {
                    debugger;
                    var qt = JSON.parse(data);

                    var religion = document.getElementById("religion");
                    var religionValue = qt.data['name'];
                        
                    religion.innerHTML = religion.innerHTML +
                        '<option>' + religionValue + '</option>';
                }
            });
            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});