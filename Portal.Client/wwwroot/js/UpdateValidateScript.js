debugger;
var firstname = document.getElementById('firstname');
var lastname = document.getElementById('lastname');
var email = document.getElementById('email');
var univ = document.getElementById('university');
var dept = document.getElementById('department');
var ipk = document.getElementById('gpa');
var kota = document.getElementById('hometown');
var phone = document.getElementById('hp');
var birthdate = document.getElementById('birthdate');

var validNumber = /[0-9]|\./;
//var validIpk = /^ (([0 - 4]{ 1}\s)| ([0 - 3]{ 1 } \.\d{ 0, 2 } \s))| [4]\.[0]{ 0, 2 } \s/;

function validFirstName() {
    if (firstname.value == '') {
        firstname.classList.remove("is-valid");
        firstname.classList.add("is-invalid");
    }
    else {
        firstname.classList.remove("is-invalid");
        firstname.classList.add("is-valid");
    }
}

function validLastName() {
    if (lastname.value == '') {
        lastname.classList.remove("is-valid");
        lastname.classList.add("is-invalid");
    }
    else {
        lastname.classList.remove("is-invalid");
        lastname.classList.add("is-valid");
    }
}

function validPhone() {
    if (phone.value == '') {
        phone.classList.remove("is-valid");
        phone.classList.add("is-invalid");
    }
    else {
        if (phone.value.match(validNumber)) {
            phone.classList.remove("is-invalid");
            phone.classList.add("is-valid");
        }
        else
        {
            phone.classList.remove("is-valid");
            phone.classList.add("is-invalid");
        }
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
        //if (ipk.value.match(validIpk))
        //{
            ipk.classList.remove("is-invalid");
            ipk.classList.add("is-valid");
        //}
        //ipk.classList.remove("is-valid");
        //ipk.classList.add("is-invalid");
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

