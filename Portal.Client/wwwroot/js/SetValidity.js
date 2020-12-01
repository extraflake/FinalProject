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

function genderValid() {
    if (gender.value == '') {
        gender.classList.remove("dropdown-valid");
        gender.classList.add("dropdown-invalid");
    }
    else {
        gender.classList.remove("dropdown-invalid");
        gender.classList.add("dropdown-valid");
    }
}

function religionValid() {
    if (religion.value == '') {
        religion.classList.remove("dropdown-valid");
        religion.classList.add("dropdown-invalid");
    }
    else {
        religion.classList.remove("dropdown-invalid");
        religion.classList.add("dropdown-valid");
    }
}

function validfName() {
    if (fName.value == '') {
        fName.classList.remove("is-valid");
        fName.classList.add("is-invalid");
    }
    else {
        fName.classList.remove("is-invalid");
        fName.classList.add("is-valid");
    }
}

function validlName() {
    if (lName.value == '') {
        lName.classList.remove("is-valid");
        lName.classList.add("is-invalid");
    }
    else {
        lName.classList.remove("is-invalid");
        lName.classList.add("is-valid");
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

function validPassword() {
    if (password.value == '') {
        password.classList.remove("is-valid");
        password.classList.add("is-invalid");
    }
    else {
        password.classList.remove("is-invalid");
        password.classList.add("is-valid");
    }
}

function Confirm() {
    debugger
    if (confirm.value == '') {
        confirm.classList.remove("is-valid");
        confirm.classList.add("is-invalid");
    }
    else {
        if (password.value == confirm.value) {
            confirm.classList.remove("is-invalid");
            confirm.classList.add("is-valid");
        }
        else
        {
            confirm.classList.remove("is-valid");
            confirm.classList.add("is-invalid");
        }
    }
}



function ValidateEmail() {
    var mailformat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
    if (email.value.match(mailformat)) {
        email.classList.remove("is-invalid");
        email.classList.add("is-valid");
    }
    else {
        email.classList.remove("is-valid");
        email.classList.add("is-invalid");
    }
}

function validBirth() {
    if (birthdate.value == '') {
        birthdate.classList.remove("is-valid");
        birthdate.classList.add("is-invalid");
    }
    else {
        birthdate.classList.remove("is-invalid");
        birthdate.classList.add("is-valid");
    }
}

