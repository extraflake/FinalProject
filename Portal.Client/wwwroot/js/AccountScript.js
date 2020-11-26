function SignUp() {
    //debugger;
    var fName = document.getElementById('fname-column');
    var lName = document.getElementById('last-name-column');
    var email = document.getElementById('email-column');
    var password = document.getElementById('password-column');
    var confirm = document.getElementById('confirm-column');
    var userName = document.getElementById('username-column');
    var phone = document.getElementById('phone-column');
    var birthdate = document.getElementById('birthdate-column');

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
    var RegisterVM = new Object();
    RegisterVM.FirstName = fName.value;
    RegisterVM.LastName = lName.value;
    RegisterVM.User_Email = email.value;
    RegisterVM.Username = userName.value;
    RegisterVM.User_Password = password.value;
    RegisterVM.Phone = phone.value;
    RegisterVM.BirthDate = birthdate.value;
    RegisterVM.Gender = document.getElementById('gender-floating').value;
    RegisterVM.ReligionId = document.getElementById('religion-floating').value;

    console.log(RegisterVM.ReligionId);
    console.log(RegisterVM.Gender);

    $.ajax({
        type: "POST",
        url: '/Account/Register',
        data: RegisterVM
    }).then((result) => {
        //console.log(result.data);
        //debugger;
        //console.log(result.token);
        if (result.data == "berhasil") {
            swal("Success!", "Registrasi anda berhasil!", "success").
                then(() => {
                    window.location = result.url;
                });
        }
        else swal("Error!", result.data, "error")
    });
}

function ClearScreen() {
    $('#email').val('');
    $('#password').val('');
}

function SignIn() {
    var user = document.getElementById('user');
    var password = document.getElementById('password');

    var RegisterVM = new Object();
    RegisterVM.User_Email = user.value;
    RegisterVM.Username = user.value;
    RegisterVM.Phone = user.value;
    RegisterVM.User_Password = password.value;

    $.ajax({
        type: "POST",
        url: '/Account/Login',
        data: RegisterVM
    }).then((result) => {
        //console.log(result.data);
        if (result.data == "berhasil") {
            console.log(result.token);
            //swal("Success!", "Registrasi anda berhasil!", "success");
            window.location = result.url;
        }
        else swal("Error!", result.data, "error")
    });
}

function Forgot() {
    var email = document.getElementById('email-column');

    var RegisterVM = new Object();
    RegisterVM.User_Email = email.value;

    $.ajax({
        type: "PATCH",
        url: '/Account/Forgot',
        data: RegisterVM
    }).then((result) => {
        if (result.data == "berhasil") {
            //console.log(result.token);
            swal("Success!", "Token telah terkirim ke email anda!", "success").
                then(() => {
                    swal("Info", "Silahkan login dengan token di email anda", "info");
                }).then(() => {
                    window.location = result.url;
                });
        }
        else swal("Error!", result.data, "error")
    });
}

function Change() {
    var newPass = document.getElementById('new');
    var confirm = document.getElementById('confirm');

    if (newPass.value != confirm.value) {
        swal("Error!", "Password yang anda masukkan tidak cocok", "error");
    }
    else {
        var RegisterVM = new Object();
        RegisterVM.User_Password = newPass.value;

        $.ajax({
            type: "PUT",
            url: '/Account/Change',
            data: RegisterVM
        }).then((result) => {
            if (result.data == "berhasil") {
                //console.log(result.token);
                swal("Success!", "Password anda telah berubah", "success").
                    then(() => {
                        window.location = result.url;
                    });
            }
            else swal("Error!", result.data, "error")
        });
    }
}