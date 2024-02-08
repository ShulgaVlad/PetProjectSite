
let eyeicon = document.getElementById("eyeicon");
let password = document.getElementById("password");
eyeicon.onclick = function () {
    if (password.type == "password") {
        password.type = "text";
        eyeicon.src = "/images/password_show.png"
    }
    else {
        password.type = "password";
        eyeicon.src = "/images/password_hide.png"
    }
}