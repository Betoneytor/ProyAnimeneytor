$(document).ready(function () {
    /*
     *CORRECCION: El plugin requiere que la tabla tenga un thead con los encabezados de la
     * tabla y el gridview no genera este elemento, al traducir el gridview a tabla solo genera
     * un tbody y un tfooter, por lo que en el siguiente código adecúo la tabla antes de 
     * activar el plugin
     * */
    let tabla = $('#contenido_gvUnidades');
    //Obtengo la fila de los encabezados en el gridview colocó en el tbody (la primera)
    let fila = $(tabla).find("tbody tr:first").clone();
    //La elimino del tbody
    $(tabla).find("tbody tr:first").remove();
    //Creo un elemento thead y le añado la fila de encabezados
    let encabezado = $("<thead />").append(fila);
    //Añado el thead a la tabla antes del tbody
    $(tabla).children('tbody').before(encabezado);
    //Activamos el plugin
    $('#contenido_gvUnidades').DataTable();

    $("#btnValidar").on('click', validar);
    $(".btn").addClass("text-bold");



    function validar(e) {


        if ($("#txtAgregarEditarNUnidad").val().trim().length >= 1 && $("#txtAgregarEditarNUnidad").val().trim().length <= 15) {
            $("#txtAgregarEditarNUnidad").removeClass("is-invalid");
            $("#txtAgregarEditarNUnidad").addClass("is-valid");
            if ($("#txtAgregarEditarCalificacion").val().trim().length >= 1 && $("#txtAgregarEditarCalificacion").val().trim().length <= 100) {
                $("#txtAgregarEditarCalificacion").removeClass("is-invalid");
                $("#txtAgregarEditarCalificacion").addClass("is-valid");

                $("#btnAceptar").prop("disabled", false);
            } else {
                $("#txtAgregarEditarCalificacion").removeClass("is-valid");
                $("#txtAgregarEditarCalificacion").addClass("is-invalid");
                $("#btnAceptar").prop("disabled", true);
            }
           
            
        } else {
            $("#txtAgregarEditarNUnidad").removeClass("is-valid");
            $("#txtAgregarEditarNUnidad").addClass("is-invalid");
            $("#btnAceptar").prop("disabled", true);
        }
    }
});

