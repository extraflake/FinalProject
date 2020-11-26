debugger;
var fName = document.getElementById('fname-column');
var lName = document.getElementById('last-name-column');
var email = document.getElementById('email-column');
var password = document.getElementById('password-column');
var confirm = document.getElementById('confirm-column');
var userName = document.getElementById('username-column');
var phone = document.getElementById('phone-column');
var birthdate = document.getElementById('birthdate-column');

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
    }
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
    //var mailformat = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var mailformat = /^(([^<>()\[\]\.,;:\s@\"]+(\.[^<>()\[\]\.,;:\s@\"]+)*)|(\".+\"))@(([^<>()[\]\.,;:\s@\"]+\.)+[^<>()[\]\.,;:\s@\"]{2,})$/i
    ///^w+([.-]?w+)*@w+([.-]?w+)*(.w{2,3})+$/
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

