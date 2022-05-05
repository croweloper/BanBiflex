function ValidateEmail() {
    var email = document.getElementById("mail").value;
    var spanError = document.getElementById("spanError");
    spanError.innerHTML = "";
    var expr = /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
    if (!expr.test(email)) {
        spanError.innerHTML = "Ingrese un correo válido";
    }
}