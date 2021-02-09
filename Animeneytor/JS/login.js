$(document).ready(function () {

    

    //Funcion para validar el correo cada que escribe
    setEventToEmailBox('txtCorreo', 'emailHelp', 'emailHelpLimpio');
    setEventToEmailBox('rtxtCorreo', 'remailHelp', 'remailHelpLimpio');
    setEventToEmailBox('txtCorreoConfirm', 'emailConfirmHelp', 'emailConfirmHelpLimpio');

    //Funcion para validar el correo cada que escribe
    setEventToPassBox("txtPass", "passHelp");
    setEventToPassBox("rtxtPass", "rpassHelp");
    setEventToPassBox("txtPassConfirm", "rpassConfirmHelp");

    //Click al boton de login
    $("#btnLogin").click(
        function (evt) {
            let txtMail = getValue("txtCorreo");            
            let txtPass = getValue("txtPass");    

            //si el correo esta vacio muestra la etiqueta y finaliza el metodo
            if (txtMail === "") {
                showElement("emailHelpLimpio");  
                return;
            }

            //si la contraseña esta vacia muestra la etiqueta y finaliza el metodo
            if (txtPass === "") {
                showElement("passHelp");
                return;
            }

            //si el correo no cumple con la expresion regular muestra la etiqueta y finaliza el metodo
            if (!validateEmail(txtMail)) {
                showElement("emailHelp");                
                return;
            }

            var actionData = "{'correo': '" + txtMail + "','password': '" + txtPass + "'}";

            //Ajax que hace la peticion al servicio
            $.ajax(
                {
                    url: "loginForm.aspx/GetLogin",
                    data: actionData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        let exist = msg.d;

                        if (msg.d === "true") {
                            toggleAlert("bsalertOk");
                            window.location.href ="/inicio.aspx"
                        } else {
                            toggleAlert("bsalertError");
                        }

                    },
                    error: function (result) {
                        console.log(result);
                    }
                }); 

            
        }
    );

    //Hace visible el formulario de registro y oculta el formulario de login
    $("#registerLink").click(
        function (evt) {
            showElement("formRegister");
            hideElement("formLogin");
            $("#tilte").text("Registrarse");
        }
    );

    //Hace visible el formulario de login y oculta el formulario de registro
    $("#btnLoginLink").click(
        function (evt) {
            showElement("formLogin");
            hideElement("formRegister"); 
            $("#tilte").text("Iniciar Sesión");
        }
    );

    $("#btnRegister").click(
        function () {

            let txtMail = getValue("rtxtCorreo");
            let txtPass = getValue("rtxtPass"); 

            let txtCMail = getValue("txtCorreoConfirm");
            let txtCPass = getValue("txtPassConfirm"); 



            //ostrar etiqueta de campos diferentes
            if (txtMail !== txtCMail) {
                showElement("emailSamemHelp");
                return;
            } else {
                hideElement("emailSamemHelp");
            }
            if (txtPass !== txtCPass) {
                showElement("rpassSameHelp");
                return;
            } else {
                hideElement("rpassSameHelp");
            }

            //mostrar etiquetas de campo obligatorio
            if (txtMail === "") {
                showElement("remailHelpLimpio");
                return;
            }
            if (txtCMail === "") {
                showElement("emailConfirmHelpLimpio");
                return;
            }            
            if (txtPass === "") {
                showElement("rpassHelp");                
                return;
            }
            if (txtCPass === "") {
                showElement("rpassConfirmHelp");
                return;
            }

            //si el correo no cumple con la expresion regular muestra la etiqueta y finaliza el metodo
            if (!validateEmail(txtMail)) {
                showElement("remailHelp");
                return;
            }
            //si el correo no cumple con la expresion regular muestra la etiqueta y finaliza el metodo
            if (!validateEmail(txtCMail)) {
                showElement("emailConfirmHelp");
                return;
            }

            var actionData = "{'correo': '" + txtMail + "','password': '" + txtPass + "'}";

            //Ajax que hace la peticion al servicio
            $.ajax(
                {
                    url: "loginForm.aspx/postRegister",
                    data: actionData,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        let exist = msg.d;

                        if (msg.d === "true") {
                            toggleAlert("bsalertOk");
                            showElement("formLogin");
                            hideElement("formRegister");
                            $("#tilte").text("Iniciar Sesión");
                            setTimeout(function () {
                                setValue("txtCorreo", txtMail);
                                setValue("txtPass", txtPass);
                            }, 500);
                        } else {
                            toggleAlert("bsalertError");
                        }
                    },
                    error: function (result) {
                        console.log(result);
                    }
                }); 
        }
    );


  //  $("#btnLogin").trigger("click");


});

//funcion generica para agregar el evento a los box
function setEventToEmailBox(idBox, idHelpOne, idHelpTwo) {
    $("#" + idBox).keyup(
        function (evt) {
            let txtMail = getValue(idBox);

            if (!validateEmail(txtMail)) {
                showElement(idHelpOne);
            } else {
                hideElement(idHelpOne);
            }
            if (txtMail === "") {
                hideElement(idHelpOne);
            } else {
                hideElement(idHelpTwo);
            }
        }
    );
}

//funcion generica para agregar el evento a los box password
function setEventToPassBox(idBox, idHelpTwo) {
    $("#" + idBox).keyup(
        function (evt) {
            let txtPass = getValue(idBox);

            if (txtPass !== "") {
                hideElement(idHelpTwo);
            }
        }
    );
}

//Funcion que muestra el alert de bootstrap
function toggleAlert(id) {
    $("#" + id).toggleClass('in out');
    setTimeout(function () {
        $("#" + id).toggleClass('out in');
    }, 5000)
    return false; 
}

//Validar cadena email
function validateEmail(email) {
    const re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

//Ocultar elementos
function hideElement(id) {
    $("#"+id).css({ "display": "none" });
}

//Mostrar elementos
function showElement(id) {
    $("#" + id).css({ "display": "block" });
}

//obtener texto de un input
function getValue(id) {
    return $("#" + id).val();
}

//setear texto a un input
function setValue(id, value) {
    $("#" + id).val(value);
}