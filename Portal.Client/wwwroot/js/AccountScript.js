var RegisterVM = new Object();

function SignUp() {
    //debugger;
    var checker = new Array();
    var dropDownChecker = new Array();

    var fName = document.getElementById('fname-column');
    var lName = document.getElementById('last-name-column');
    var email = document.getElementById('email-column');
    var password = document.getElementById('password-column');
    var confirm = document.getElementById('confirm-column');
    var userName = document.getElementById('username-column');
    var phone = document.getElementById('phone-column');
    var birthdate = document.getElementById('birthdate-column');
    var gender = document.getElementById('gender-floating');
    var religion = document.getElementById('religion');

    //genderValid();
    //religionValid();

    checker.push(fName, lName, email, password, confirm, userName, phone, birthdate);
    dropDownChecker.push(gender, religion);

    RegisterVM.FirstName = fName.value;
    RegisterVM.LastName = lName.value;
    RegisterVM.User_Email = email.value;
    RegisterVM.Username = userName.value;
    RegisterVM.User_Password = password.value;
    RegisterVM.Phone = phone.value;
    RegisterVM.BirthDate = birthdate.value;
    RegisterVM.Gender = document.getElementById('gender-floating').value;
    RegisterVM.ReligionId = document.getElementById('religion').value;

    var counter = null;

    checker.forEach((item) => {
        if (item.classList.contains('is-invalid') || !item.classList.contains('is-valid')) {
            item.classList.remove('is-invalid');
            item.classList.add('is-invalid');
        }
        else if (item.classList.contains('is-valid')) {
            counter++;
        }
    });

    dropDownChecker.forEach((item) => {
        if (item.classList.contains('dropdown-invalid') || !item.classList.contains('dropdown-valid')) {
            item.classList.remove('dropdown-invalid');
            item.classList.add('dropdown-invalid');
        }
        else if (item.classList.contains('dropdown-valid')) {
            counter++;
        }
    });

    if (counter == 10) {
        Register();
    }
    else swal("Error!", "Cek kembali data yang anda masukkan!", "error");
}

function Register() {
    $.ajax({
        type: "POST",
        url: '/Account/Register',
        data: RegisterVM,
        beforeSend: function () {
            debugger;
            var createLoader = document.getElementById("loader");
            createLoader.classList.remove('hidden');
        },
        complete: function () {
            var createLoader = document.getElementById("loader");
            createLoader.classList.add('hidden');
        }
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

function ClearScreen() {
    $('#email').val('');
    $('#password').val('');
}

function SignIn() {
    var user = document.getElementById('username-column');
    var password = document.getElementById('password-column');

    var checker = new Array();
    checker.push(user, password);
    var counter = null;

    checker.forEach((item) => {
        if (item.classList.contains('is-invalid') || !item.classList.contains('is-valid')) {
            item.classList.remove('is-invalid');
            item.classList.add('is-invalid');
        }
        else if (item.classList.contains('is-valid')) {
            counter++;
        }
    });

    var RegisterVM = new Object();
    RegisterVM.User_Email = user.value;
    RegisterVM.Username = user.value;
    RegisterVM.Phone = user.value;
    RegisterVM.User_Password = password.value;

    if (counter == 2) {
        $.ajax({
            type: "POST",
            url: '/Account/Login',
            data: RegisterVM,
            beforeSend: function () {
                debugger;
                var createLoader = document.getElementById("loader");
                createLoader.classList.remove('hidden');
            },
            complete: function () {
                var createLoader = document.getElementById("loader");
                createLoader.classList.add('hidden');
            }
        }).then((result) => {
            //console.log(result.data);
            if (result.data == "berhasil") {
                //console.log(result.token);
                //swal("Success!", "Registrasi anda berhasil!", "success");
                window.location = result.url;
            }
            else swal("Error!", result.data, "error");
        });
    }
    else swal("Error!", "Cek kembali data yang anda isikan", "error");
}

function Forgot() {
    var email = document.getElementById('email-column');

    var RegisterVM = new Object();
    RegisterVM.User_Email = email.value;

    if (email.classList.contains('is-valid')) {
        $.ajax({
            type: "PATCH",
            url: '/Account/Forgot',
            data: RegisterVM,
            beforeSend: function () {
                debugger;
                var createLoader = document.getElementById("loader");
                createLoader.classList.remove('hidden');
            },
            complete: function () {
                var createLoader = document.getElementById("loader");
                createLoader.classList.add('hidden');
            }
        }).then((result) => {
            if (result.data == "berhasil") {
                //console.log(result.token);
                swal("Success!", "Token telah terkirim ke email anda!", "success").
                    then(() => {
                        swal("Info", "Silahkan login dengan token di email anda", "info").then(() => {
                            window.location = result.url;
                        });
                    });
            }
            else swal("Error!", result.data, "error");
        });
    }
    else if (email.classList.contains('is-invalid') || !email.classList.contains('is-valid')) {
        swal("Error!", "Isi Email anda dengan benar", "error").then(() => {
            email.classList.remove('is-invalid');
            email.classList.add('is-invalid');
        });
    }
}

function Change() {
    var password = document.getElementById('password-column');
    var confirm = document.getElementById('confirm-column');

    var checker = new Array();
    checker.push(password, confirm);
    var counter = null;

    checker.forEach((item) => {
        if (item.classList.contains('is-invalid') || !item.classList.contains('is-valid')) {
            item.classList.remove('is-invalid');
            item.classList.add('is-invalid');
        }
        else if (item.classList.contains('is-valid')) {
            counter++;
        }
    });

    if (counter == 2) {
        var RegisterVM = new Object();
        RegisterVM.User_Password = password.value;

        $.ajax({
            type: "PUT",
            url: '/Account/Change',
            data: RegisterVM,
            beforeSend: function () {
                debugger;
                var createLoader = document.getElementById("loader");
                createLoader.classList.remove('hidden');
            },
            complete: function () {
                var createLoader = document.getElementById("loader");
                createLoader.classList.add('hidden');
            }
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
    else swal("Error!", "Password yang anda masukkan tidak sesuai", "error");
}