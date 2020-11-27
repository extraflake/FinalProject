var fName = document.getElementById('fname-column');
var lName = document.getElementById('last-name-column');
var email = document.getElementById('email-column');
var password = document.getElementById('password-column');
var confirm = document.getElementById('confirm-column');
var userName = document.getElementById('username-column');
var phone = document.getElementById('phone-column');
var birthdate = document.getElementById('birthdate-column');

var RegisterVM = new Object();
RegisterVM.FirstName = fName.value;
RegisterVM.LastName = lName.value;
RegisterVM.User_Email = email.value;
RegisterVM.Username = userName.value;
RegisterVM.User_Password = password.value;
RegisterVM.Phone = phone.value;
RegisterVM.BirthDate = birthdate.value;
RegisterVM.Gender = document.getElementById('gender-floating').value;
RegisterVM.ReligionId = document.getElementById('religion').value;

$(document).ready(function () {
    //debugger;
    $.ajax({
        url: "/Account/GetNameReligion/",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (data) {
            var qt = JSON.parse(data);
            console.log(qt);
            var dropDown = document.getElementById("religion-item");
            for (var i = 0; i < qt.data.length; i++) {

                dropDown.innerHTML = dropDown.innerHTML +
                    '<option value="' + qt.data[i]['id'] + '" id="' + qt.data[i]['name'] + '">' + qt.data[i]['name'] + '</option > ';

                //dropDown.innerHTML = dropDown.innerHTML +
                //    '<option value="' + qt.data[i]['id'] + '" id="' + qt.data[i]['name'] + '">' + qt.data[i]['name'] + '</option>';
            }
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
});



function SignUp() {
    //debugger;
    if (fName.classList.contains('is-valid') && lName.classList.contains('is-valid') && email.classList.contains('is-valid') && password.classList.contains('is-valid')) {
        if (confirm.classList.contains('is-valid') && userName.classList.contains('is-valid') && phone.classList.contains('is-valid') && birthdate.classList.contains('is-valid')) {

            if (confirm.value != password.value) {
                swal("Error!", "Silahkan konfirmasi password yang anda masukkan!", "error");
            }

            else {
                Register();
            }
        }
        else swal("Error!", "Cek kembali data yang anda masukkan!", "error");
    }

    else swal("Error!", "Cek kembali data yang anda masukkan!", "error");
}

function Register() {
    

    //console.log(RegisterVM.ReligionId);
    //console.log(RegisterVM.Gender);

    $.ajax({
        type: "POST",
        url: '/Account/Register',
        data: RegisterVM
    }).then((result) => {
        if (result.data == "berhasil") {
            swal("Success!", "Registrasi anda berhasil!", "success").
                then(() => {
                    window.location = result.url;
                });
        }
        else swal("Error!", result.data, "error")
    });
}