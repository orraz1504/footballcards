function validate(){
    return validatePasword();
}
function validatePasword(){
    let pass = document.getElementById("pass");
    let repass= document.getElementById("repass");

    if( pass.value == repass.value ){
        repass.setCustomValidity("");
        return true;
    }
    else{
        repass.setCustomValidity("Passwords Don't Match");
        document.body.style.background="#bd5757";
        pass.onchange=validatePasword;
        repass.onkeyup=validatePasword;
        return false;
    }
}
function error_login(){
    document.body.style.background="#bd5757";
}