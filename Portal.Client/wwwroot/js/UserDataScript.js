$(document).ready(function () {
    //debugger;
    //User Data
    $.ajax({
        url: "/Registration/GetUserData/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        beforeSend: function () {
            debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        },
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
        beforeSend: function () {
            debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        },
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

            //debugger;
            var gender = document.getElementById("gender");
            var genderValue = qt.data['gender'];
            if (genderValue == 'Pria') {
                gender.selectedIndex = "0";
            }
            else if (genderValue == 'Wanita') {
                gender.selectedIndex = "1";
            }
            else {
                gender.selectedIndex = "2";
            }


            // Get Religion
            //debugger;
            var RegisterVM = new Object();
            RegisterVM.ReligionId = qt.data['religionID'];

            $(document).ready(function () {
                //debugger;
                $.ajax({
                    url: "/Account/GetNameReligion/",
                    type: "GET",
                    contentType: "application/json;charset=utf-8",
                    dataType: "json",
                    async: false,
                    beforeSend: function () {
                        debugger;
                        var createLoader = document.getElementById("loader");
                        createLoader.classList.remove('hidden');
                    },
                    complete: function () {
                        var createLoader = document.getElementById("loader");
                        createLoader.classList.add('hidden');
                    },
                    success: function (data) {

                        
                        //debugger;
                        var qt = JSON.parse(data);
                        //console.log(qt);
                        var dropDown = document.getElementById("religion");
                        for (var i = 0; i < qt.data.length; i++) {

                            dropDown.innerHTML = dropDown.innerHTML +
                                '<option value="' + qt.data[i]['id'] + '" id="' + qt.data[i]['name'] + '">' + qt.data[i]['name'] + '</option>';
                            //debugger;
                            //console.log(document.getElementById(qt.data[i]['name']));
                        }
                        //var agama = qt.data[2]['name'];
                        //console.log(document.getElementById(qt.data[2]['name'] ).index);

                        $.ajax({
                            type: "Get",
                            url: '/Registration/GetReligion',
                            data: RegisterVM,
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            async: false,
                            beforeSend: function () {
                                debugger;
                                var createLoader = document.getElementById("loader");
                                createLoader.classList.remove('hidden');
                            },
                            complete: function () {
                                var createLoader = document.getElementById("loader");
                                createLoader.classList.add('hidden');
                            },
                            success: function (religion) {
                                //debugger;
                                var qt = JSON.parse(religion);

                                var dropDown = document.getElementById("religion");

                                //console.log(document.getElementById('Islam').value);

                                var ReligionData = qt.data['name'];
                                //console.log(ReligionData);
                                //console.log(document.getElementById(ReligionData).index);
                                //console.log((document.getElementById(ReligionData).index).toString());
                                //var religionValue = document.getElementById("religion");
                                dropDown.selectedIndex = (document.getElementById(ReligionData).index).toString();
                            }
                        });

                    },
                    error: function (errormessage) {
                        alert(errormessage.responseText);
                    }
                });
            });

            
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

    
});