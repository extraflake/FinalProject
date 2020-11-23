var fName = document.getElementById('fname-column');
var lName = document.getElementById('last-name-column');
var email = document.getElementById('email-column');
var password = document.getElementById('password-column');
var confirm = document.getElementById('confirm-column');
var userName = document.getElementById('username-column');
var phone = document.getElementById('phone-column');
var birthdate = document.getElementById('birthdate-column');

function SignUp() {
    //debugger;

    if (fName.classList.contains('is-valid') && lName.classList.contains('is-valid') && email.classList.contains('is-valid') && password.classList.contains('is-valid')) {
        if (confirm.classList.contains('is-valid') && userName.classList.contains('is-valid') && phone.classList.contains('is-valid') && birthdate.classList.contains('is-valid')) {
            swal("Success!", "Registrasi anda berhasil!", "success");

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
        if (result.data == 200) {
            Swal.fire({
                position: 'center',
                icon: 'success',
                title: 'Login Success',
                showConfirmButton: false,
                timer: 3000
            }).then(() => {
                window.location = result.url;
            });
        }
    }).catch((error) => {
        Swal.fire({
            position: 'top-center',
            icon: 'error',
            title: 'Login Error',
            showConfirmButton: true,
            timer: 3000
        });
        ClearScreen();
    });
}

function ClearScreen() {
    $('#email').val('');
    $('#password').val('');
}