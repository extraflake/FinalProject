var email = document.getElementById('email-column');

function Forgot() {
    var RegisterVM = new Object();
    RegisterVM.User_Email = email.value;

    $.ajax({
        type: "PATCH",
        url: '/Account/Forgot',
        data: RegisterVM
    }).then((result) => {
        if (result.data == "berhasil") {
            console.log(result.token);
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