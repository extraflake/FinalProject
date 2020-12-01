//debugger;
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

// Checker
var userNameCheck = document.getElementById('username-checker');
var emailCheck = document.getElementById('email-checker');
var phoneCheck = document.getElementById('phone-checker');
var fnameCheck = document.getElementById('fname-checker');
var lnameCheck = document.getElementById('lname-checker');
var agamaCheck = document.getElementById('agama-checker');
var genderCheck = document.getElementById('gender-checker');
var birthCheck = document.getElementById('birthdate-checker');
var passwordCheck = document.getElementById('password-checker');
var confirmCheck = document.getElementById('confirm-checker');

function genderValid() {
    if (gender.value == '') {
        gender.classList.remove("dropdown-valid");
        gender.classList.add("dropdown-invalid");
        genderCheck.classList.remove("checker-hidden");
        genderCheck.innerHTML = "Gender Tidak Boleh Kosong";
    }
    else {
        gender.classList.remove("dropdown-invalid");
        gender.classList.add("dropdown-valid");
        genderCheck.classList.add("checker-hidden");
    }
}

function religionValid() {
    if (religion.value == '') {
        religion.classList.remove("dropdown-valid");
        religion.classList.add("dropdown-invalid");
        agamaCheck.classList.remove("checker-hidden");
        agamaCheck.innerHTML = "Religion Tidak Boleh Kosong";
    }
    else {
        religion.classList.remove("dropdown-invalid");
        religion.classList.add("dropdown-valid");
        agamaCheck.classList.add("checker-hidden");
    }
}

function validfName() {
    if (fName.value == '') {
        fName.classList.remove("is-valid");
        fName.classList.add("is-invalid");
        fnameCheck.classList.remove("checker-hidden");
        fnameCheck.innerHTML = "First Name Tidak Boleh Kosong";
    }
    else {
        fName.classList.remove("is-invalid");
        fName.classList.add("is-valid");
        fnameCheck.classList.add("checker-hidden");
    }
}

function validlName() {
    if (lName.value == '') {
        lName.classList.remove("is-valid");
        lName.classList.add("is-invalid");
        lnameCheck.classList.remove("checker-hidden");
        lnameCheck.innerHTML = "Last Name Tidak Boleh Kosong";
    }
    else {
        lName.classList.remove("is-invalid");
        lName.classList.add("is-valid");
        lnameCheck.classList.add("checker-hidden");
    }
}

function validPhone() {
    if (phone.value == '') {
        phone.classList.remove("is-valid");
        phone.classList.add("is-invalid");
    }
    else {
        phone.classList.remove("is-invalid");
        phone.classList.add("is-valid");
    }
}

function validUserName() {
    if (userName.value == '') {
        userName.classList.remove("is-valid");
        userName.classList.add("is-invalid");
        userNameCheck.classList.remove("checker-hidden");
        userNameCheck.innerHTML = "Username Tidak Boleh Kosong";
    }
    else {
        userName.classList.remove("is-invalid");
        userName.classList.add("is-valid");
        userNameCheck.classList.add("checker-hidden");
    }
}

function checkUserName() {
    debugger;
    var RegisterVM = new Object();
    RegisterVM.Username = userName.value;

    $.ajax({
        type: "POST",
        url: '/Account/CheckAvailUser',
        data: RegisterVM
    }).then((result) => {
        if (result.data == "berhasil") {
            if (userName.value == '') {
                //userNameCheck.innerHTML = "Username tidak boleh kosong";
                userName.classList.remove("is-valid");
                userName.classList.add("is-invalid");
                //userNameCheck.classList.add("checker-hidden");
                userNameCheck.classList.remove("checker-hidden");
                userNameCheck.innerHTML = "Username tidak boleh kosong";
            }
            else {
                userName.classList.remove("is-invalid");
                userName.classList.add("is-valid");
                userNameCheck.classList.add("checker-hidden");
            }
            
        }
        else {
            userName.classList.remove("is-valid");
            userName.classList.add("is-invalid");
            userNameCheck.classList.remove("checker-hidden");
            userNameCheck.innerHTML = "Username sudah digunakan";
        }
    });
}

function checkEmail() {
    debugger;
    var RegisterVM = new Object();
    RegisterVM.User_Email = email.value;

    $.ajax({
        type: "POST",
        url: '/Account/CheckAvailEmail',
        data: RegisterVM
    }).then((result) => {
        if (result.data == "berhasil") {
            if (email.value == '') {
                //userNameCheck.innerHTML = "Username tidak boleh kosong";
                email.classList.remove("is-valid");
                email.classList.add("is-invalid");
                //userNameCheck.classList.add("checker-hidden");
                emailCheck.classList.remove("checker-hidden");
                emailCheck.innerHTML = "email tidak boleh kosong";
            }
            else {
                var mailformat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
                if (email.value.match(mailformat)) {
                    email.classList.remove("is-invalid");
                    email.classList.add("is-valid");
                    emailCheck.classList.add("checker-hidden");
                }
                else {
                    email.classList.remove("is-valid");
                    email.classList.add("is-invalid");
                    emailCheck.classList.remove("checker-hidden");
                    emailCheck.innerHTML = "email tidak sesuai format : axi@gmail.com";
                }
            }
        }
        else {
            email.classList.remove("is-valid");
            email.classList.add("is-invalid");
            emailCheck.classList.remove("checker-hidden");
            emailCheck.innerHTML = "Email sudah digunakan";
        }
    });
}


function checkPhone() {
    debugger;
    var RegisterVM = new Object();
    RegisterVM.Phone = phone.value;

    $.ajax({
        type: "POST",
        url: '/Account/CheckAvailPhone',
        data: RegisterVM
    }).then((result) => {
        if (result.data == "berhasil") {
            if (phone.value == '') {
                //userNameCheck.innerHTML = "Username tidak boleh kosong";
                phone.classList.remove("is-valid");
                phone.classList.add("is-invalid");
                //userNameCheck.classList.add("checker-hidden");
                phoneCheck.classList.remove("checker-hidden");
                phoneCheck.innerHTML = "Nomor Hp tidak boleh kosong";
            }
            else {
                phone.classList.remove("is-invalid");
                phone.classList.add("is-valid");
                phoneCheck.classList.add("checker-hidden");
            }

        }
        else {
            phone.classList.remove("is-valid");
            phone.classList.add("is-invalid");
            phoneCheck.classList.remove("checker-hidden");
            phoneCheck.innerHTML = "Nomor Hp sudah digunakan";
        }
    });
}

function validEmail()
{
    if (email.value == '') {
        //userNameCheck.innerHTML = "Username tidak boleh kosong";
        email.classList.remove("is-valid");
        email.classList.add("is-invalid");
        //userNameCheck.classList.add("checker-hidden");
        emailCheck.classList.remove("checker-hidden");
        emailCheck.innerHTML = "email tidak boleh kosong";
    }
    else {
        var mailformat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
        if (email.value.match(mailformat)) {
            email.classList.remove("is-invalid");
            email.classList.add("is-valid");
            emailCheck.classList.add("checker-hidden");
        }
        else {
            email.classList.remove("is-valid");
            email.classList.add("is-invalid");
            emailCheck.classList.remove("checker-hidden");
            emailCheck.innerHTML = "email tidak sesuai format : axi@gmail.com";
        }
    }
}

function loginPassword()
{
    if (password.value == '') {
        password.classList.remove("is-valid");
        password.classList.add("is-invalid");
        passwordCheck.classList.remove("checker-hidden");
        passwordCheck.innerHTML = "Password Tidak Boleh Kosong";
    }
    else {
        password.classList.remove("is-invalid");
        password.classList.add("is-valid");
        passwordCheck.classList.add("checker-hidden");
    }
}

function validPassword() {
    var regexPassword = /^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])/;
    var regexPasswordmin = /^(?=.{8,})/;
    if (password.value == '') {
        password.classList.remove("is-valid");
        password.classList.add("is-invalid");
        passwordCheck.classList.remove("checker-hidden");
        passwordCheck.innerHTML = "Password Tidak Boleh Kosong";
    }
    else {
        debugger;
        if (password.value.match(regexPasswordmin)) {
            debugger
            if (password.value.match(regexPassword)) {
                password.classList.remove("is-invalid");
                password.classList.add("is-valid");
                passwordCheck.classList.add("checker-hidden");
            }
            else
            {
                password.classList.remove("is-valid");
                password.classList.add("is-invalid");
                passwordCheck.classList.remove("checker-hidden");
                passwordCheck.innerHTML = "Password ex : Immortal11@";
            }
        }
        else
        {
            debugger;
            password.classList.remove("is-valid");
            password.classList.add("is-invalid");
            passwordCheck.classList.remove("checker-hidden");
            passwordCheck.innerHTML = "Password Minimal 8 Character";
        }
    }
}

function Confirm() {
    debugger
    if (confirm.value == '') {
        confirm.classList.remove("is-valid");
        confirm.classList.add("is-invalid");
        confirmCheck.classList.remove("checker-hidden");
        confirmCheck.innerHTML = "Confirm Password Tidak Boleh Kosong";
    }
    else {
        if (password.value == confirm.value) {
            confirm.classList.remove("is-invalid");
            confirm.classList.add("is-valid");
            confirmCheck.classList.add("checker-hidden");
        }
        else
        {
            confirm.classList.remove("is-valid");
            confirm.classList.add("is-invalid");
            confirmCheck.classList.remove("checker-hidden");
            confirmCheck.innerHTML = "Confirm Password Tidak Sama";
        }
    }
}

function validBirth() {
    if (birthdate.value == '') {
        birthdate.classList.remove("is-valid");
        birthdate.classList.add("is-invalid");
        birthCheck.classList.remove("checker-hidden");
        birthCheck.innerHTML = "Birth Date Tidak Boleh Kosong";
    }
    else {
        birthdate.classList.remove("is-invalid");
        birthdate.classList.add("is-valid");
        birthCheck.classList.add("checker-hidden");
    }
}
