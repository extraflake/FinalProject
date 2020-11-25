debugger;
var fName = document.getElementById('fullname');
var email = document.getElementById('email');
var univ = document.getElementById('university');
var dept = document.getElementById('department');
var ipk = document.getElementById('gpa');
var kota = document.getElementById('hometown');
var phone = document.getElementById('hp');
var birthdate = document.getElementById('birthdate');

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

function validUniv() {
    if (univ.value == '') {
        univ.classList.remove("is-valid");
        univ.classList.add("is-invalid");
    }
    else {
        univ.classList.remove("is-invalid");
        univ.classList.add("is-valid");
    }
}

function validKota() {
    if (kota.value == '') {
        kota.classList.remove("is-valid");
        kota.classList.add("is-invalid");
    }
    else {
        kota.classList.remove("is-invalid");
        kota.classList.add("is-valid");
    }
}

function validDept() {
    if (dept.value == '') {
        dept.classList.remove("is-valid");
        dept.classList.add("is-invalid");
    }
    else {
        dept.classList.remove("is-invalid");
        dept.classList.add("is-valid");
    }
}

function validIpk() {
    debugger
    if (ipk.value == '') {
        ipk.classList.remove("is-valid");
        ipk.classList.add("is-invalid");
    }
    else {
            confirm.classList.remove("is-invalid");
            confirm.classList.add("is-valid");
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

