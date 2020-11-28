//debugger;
var firstname = document.getElementById('firstname');
var lastname = document.getElementById('lastname');
var email = document.getElementById('email');
var phone = document.getElementById('hp');
var birthdate = document.getElementById('birthdate');
var gender = document.getElementById('gender');
var religion = document.getElementById('religion');
var univ = document.getElementById('university');
var dept = document.getElementById('department');
var degree = document.getElementById('degree');
var gradyear = document.getElementById('gradyear');
var ipk = document.getElementById('gpa');

var validNumber = /[0-9]|\./;
//var validIpk = /^ (([0 - 4]{ 1}\s)| ([0 - 3]{ 1 } \.\d{ 0, 2 } \s))| [4]\.[0]{ 0, 2 } \s/;

var RegisterVM = new Object();

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

function validUniv() {
    if (univ.value == '') {
        univ.classList.remove("dropdown-valid");
        univ.classList.add("dropdown-invalid");
    }
    else {
        univ.classList.remove("dropdown-invalid");
        univ.classList.add("dropdown-valid");
    }
}

function validDepartment() {
    if (dept.value == '') {
        dept.classList.remove("dropdown-valid");
        dept.classList.add("dropdown-invalid");
    }
    else {
        dept.classList.remove("dropdown-invalid");
        dept.classList.add("dropdown-valid");
    }
}

function validDegree() {
    if (degree.value == '') {
        degree.classList.remove("dropdown-valid");
        degree.classList.add("dropdown-invalid");
    }
    else {
        degree.classList.remove("dropdown-invalid");
        degree.classList.add("dropdown-valid");
    }

}

function validYear() {
    debugger;
    if (gradyear.value == '') {
        gradyear.classList.remove("dropdown-valid");
        gradyear.classList.add("dropdown-invalid");
    }
    else {
        gradyear.classList.remove("dropdown-invalid");
        gradyear.classList.add("dropdown-valid");
    }

}

function validFirstName() {
    //debugger;
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
    //debugger;
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
        else {
            phone.classList.remove("is-valid");
            phone.classList.add("is-invalid");
        }
    }
}

function validIpk() {
    //debugger
    if (ipk.value == '') {
        ipk.classList.remove("is-valid");
        ipk.classList.add("is-invalid");
    }
    else {
        ipk.classList.remove("is-invalid");
        ipk.classList.add("is-valid");
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



function Submit() {
    var checker = new Array();
    var dropDownChecker = new Array();
    var EditProfileVM = new Object();

    debugger;
    //Check all validity
    genderValid();
    religionValid();
    validUniv();
    validDepartment();
    validDegree();
    validYear();
    validFirstName();
    validLastName();
    validPhone();
    validIpk();
    ValidateEmail();
    validBirth();

    var fname = document.getElementById('firstname');
    var lname = document.getElementById('lastname');
    var email = document.getElementById('email');
    var phone = document.getElementById('hp');
    var birth = document.getElementById('birthdate');
    var GPA = document.getElementById('gpa');

    EditProfileVM.FirstName = fname.value;
    EditProfileVM.LastName = lname.value;
    EditProfileVM.User_Email = email.value;
    EditProfileVM.Phone = phone.value;
    EditProfileVM.BirthDate = birth.value;
    EditProfileVM.GPA = GPA.value;

    checker.push(fname, lname, email, phone, birth, GPA);

    var gender = document.getElementById('gender');
    var religion = document.getElementById('religion');
    var university = document.getElementById('university');
    var department = document.getElementById('department');
    var degree = document.getElementById('degree');
    var graduate = document.getElementById('gradyear');

    EditProfileVM.Gender = gender.value;
    EditProfileVM.ReligionId = religion.value;
    EditProfileVM.UniversityId = university.value;
    EditProfileVM.DepartmentId = department.value;
    EditProfileVM.Degree = degree.value;
    EditProfileVM.GraduateYear = graduate.value;

    dropDownChecker.push(gender, religion, university, department, degree, graduate);

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

    if (counter == 12) {
        Swal.fire({
            title: 'Apakah anda yakin?',
            text: 'Anda akan mengubah data anda',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Saya yakin !'
        }).then((result) => {
            $.ajax({
                type: "Put",
                url: '/Registration/UpdateData',
                data: EditProfileVM,
                beforeSend: function () {
                    //debugger;
                    var createLoader = document.getElementById("loader");
                    createLoader.classList.remove('hidden');
                },
                complete: function () {
                    var createLoader = document.getElementById("loader");
                    createLoader.classList.add('hidden');
                },
            }).then((result) => {
                //console.log(result.data);
                //$('#files').value('');
                if (result.data == "gagal") {
                    swal("Error!", "Please try again in a moment!", "error");
                }
                else if (result.data == "sukses") {
                    swal("Success!", "Update Data Berhasil!", "success").then(() => {
                        //window.location = result.url;
                        //debugger;
                        RegisterVM.User_Email = result.email;
                        RegisterVM.User_Password = result.password;
                        RegisterVM.Phone = result.email;
                        RegisterVM.Username = result.email;
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

                    });
                }
            });
        });
    }
    else swal("Error!", "Cek kembali data yang anda masukkan!", "error");
}
