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
            //console.log(result.token);
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