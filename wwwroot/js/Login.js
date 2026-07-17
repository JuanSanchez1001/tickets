const minusculasRegex = /[a-z]/;
const mayusculaRegex = /[A-Z]/;
const numRegex = /\d/;
const caracterEspecialRegex = /[$@$!%*?&]/;

$(document).ready(function(){
    $("#new_password").keyup(function(){
        validate_password($("#new_password").val());
    });

    $("#btn-login").on('click', function(){
        Login();
    });
});

function Login(){
    console.log($("#input-login").val());
    var data = {
        nomina: $("#input-login").val()
    }
    $.ajax({
        async: true,
        url: "Auth/Login",
        type: "POST",
        data: data,
        dataType: "json",
        success: function(data){
            console.log(data);
        },
        error: function(){

        }
    });
}

function validate_password(password){
    //console.log(password)
    if(password.length > 8){
        $("#password-length").removeClass("alert-primary alert-danger").addClass("alert-success");
    }else{
        $("#password-length").removeClass("alert-primary alert-success").addClass("alert-danger");
    }
    if(minusculasRegex.test(password)){
        $("#lower-letter").removeClass("alert-primary alert-danger").addClass("alert-success");
    }else{
        $("#lower-letter").removeClass("alert-primary alert-success").addClass("alert-danger");
    }
    if(mayusculaRegex.test(password)){
        $("#upper-letter").removeClass("alert-primary alert-danger").addClass("alert-success");
    }else{
        $("#upper-letter").removeClass("alert-primary alert-success").addClass("alert-danger");
    }
    if(caracterEspecialRegex.test(password)){
        $("#especial-caracter").removeClass("alert-primary alert-danger").addClass("alert-success");
    }else{
        $("#especial-caracter").removeClass("alert-primary alert-success").addClass("alert-danger");
    }
    if(numRegex.test(password)){
        $("#password-number").removeClass("alert-primary alert-danger").addClass("alert-success");
    }else{
        $("#password-number").removeClass("alert-primary alert-success").addClass("alert-danger");
    }

}