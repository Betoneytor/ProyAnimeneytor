$(document).ready(function () {

    $("#cargando").load("/listadoNoticias.aspx");

    $("#inicio").click(
        function (evt) {
            $("#cargando").load("/listadoNoticias.aspx");

            activeElement("inicioActive");
            
            var faqToggle = document.getElementById('listaAnimesActive');
            faqToggle.classList.remove('active');



        }
    );    
    $("#lista").click(
        function (evt) {
            $("#cargando").load("/listaAnimes.aspx");

            var faqToggle = document.getElementById('inicioActive');
            faqToggle.classList.remove('active');

            activeElement("listaAnimesActive");
        }
    );

    $("#cerrarSession").click(
        function (evt) {

            $.ajax(
                {
                    url: "inicio.aspx/cerrarSession",                    
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        toggleAlertCC("bsalertOkCC");
                        setTimeout(function () {                            
                            window.location.href = "loginForm.aspx"
                        }, 2000)
                    },
                    error: function (result) {
                        console.log(result);
                    }
                }); 


        }
    );
  
  
});


//Funcion que muestra el alert de bootstrap
function toggleAlertCC(id) {
    $("#" + id).toggleClass('in out');
    setTimeout(function () {
        $("#" + id).toggleClass('out in');
    }, 3000)
    return false;
}


//Ocultar active
function activeElement(id) {
    $("#"+id).addClass("active");

}

//Mostrar acttive
function desactiveElement(id) {
    $("#" + id).removeClass("active");
    $("#"+id).toggleClass('active');

}