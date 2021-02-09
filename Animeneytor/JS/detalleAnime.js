var tipoUsuario;
$(document).ready(function () {
    let id = $("#idAnime").val();

    tipoUsuario = $("#tipoUsuarioAnimeDetalle").val();    
    if (tipoUsuario === "usuario") {
        $("#formDescargas").css("display", "none");
        $("#formExtras").css("display", "none");
    }

    loadAnimeDetalle(id);
    loadAnimeExtras(id);


    $("#favorito").click(
        function (evt) {
            var actionData3 = "{'id': '" + id + "'}";
            $.ajax(
                {
                    url: "detalleAnime.aspx/addFavorito",
                    data: actionData3,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        
                        var faqToggle = document.getElementById('favorito');
                        faqToggle.classList.remove('bg-info');
                        faqToggle.classList.remove('bg-secondary');

                        if (msg.d === "true") {                           
                            $("#favorito").addClass("bg-info");
                        } else if (msg.d ==="eliminado"){
                            $("#favorito").addClass("bg-secondary");
                        }
                    },
                    error: function (result) {
                        console.log(result);
                    }
                });
        }
    );


    $("#visto").click(
        function (evt) {
            var actionData3 = "{'id': '" + id + "'}";
            $.ajax(
                {
                    url: "detalleAnime.aspx/addVisto",
                    data: actionData3,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {
                        console.log(msg);
                        var faqToggle = document.getElementById('visto');
                        faqToggle.classList.remove('bg-info');
                        faqToggle.classList.remove('bg-secondary');

                        if (msg.d === "true") {
                            $("#visto").addClass("bg-info");
                        } else if (msg.d === "eliminado") {
                            $("#visto").addClass("bg-secondary");
                        }
                    },
                    error: function (result) {
                        console.log(result);
                    }
                });
        }
    );


    $("#porVer").click(
        function (evt) {
            var actionData3 = "{'id': '" + id + "'}";
            $.ajax(
                {
                    url: "detalleAnime.aspx/addPorVer",
                    data: actionData3,
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    success: function (msg) {

                        var faqToggle = document.getElementById('porVer');
                        faqToggle.classList.remove('bg-info');
                        faqToggle.classList.remove('bg-secondary');

                        if (msg.d === "true") {
                            $("#porVer").addClass("bg-info");
                        } else if (msg.d === "eliminado") {
                            $("#porVer").addClass("bg-secondary");
                        }
                    },
                    error: function (result) {
                        console.log(result);
                    }
                });
        }
    );

    var actionData4 = "{'id': '" + id + "'}";
    $.ajax(
        {
            url: "detalleAnime.aspx/existeVisto",
            data: actionData4,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                console.log(msg)
                var faqToggle = document.getElementById('visto');
                faqToggle.classList.remove('bg-info');
                faqToggle.classList.remove('bg-secondary');

                if (msg.d === "false") {
                    $("#visto").addClass("bg-secondary");
                } else {
                    $("#visto").addClass("bg-info");
                }
            },
            error: function (result) {
                console.log(result);
            }
        });

    $.ajax(
        {
            url: "detalleAnime.aspx/existeFavorito",
            data: actionData4,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {

                var faqToggle = document.getElementById('favorito');
                faqToggle.classList.remove('bg-info');
                faqToggle.classList.remove('bg-secondary');

                if (msg.d === "false") {
                    $("#favorito").addClass("bg-secondary");
                } else {
                    $("#favorito").addClass("bg-info");
                }
            },
            error: function (result) {
                console.log(result);
            }
        });

    $.ajax(
        {
            url: "detalleAnime.aspx/existePorVer",
            data: actionData4,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {

                var faqToggle = document.getElementById('porVer');
                faqToggle.classList.remove('bg-info');
                faqToggle.classList.remove('bg-secondary');

                if (msg.d === "false") {
                    $("#porVer").addClass("bg-secondary");
                } else {
                    $("#porVer").addClass("bg-info");
                }
            },
            error: function (result) {
                console.log(result);
            }
        });

    $("#atras").click(function () {
        $("#cargando").load("/listadoNoticias.aspx");
    });
});


function loadAnimeExtras(id) {

    var actionData2 = "{'id': '" + id + "', tipo: 'descarga'}";
    $.ajax(
        {
            url: "detalleAnime.aspx/getAnimeDescargas",
            data: actionData2,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                console.log(JSON.parse(msg.d));
                setDescargas(JSON.parse(msg.d));                
            },
            error: function (result) {
                console.log(result);
            }
        });
    var actionData3 = "{'id': '" + id + "', tipo: 'extra'}";
    $.ajax(
        {
            url: "detalleAnime.aspx/getAnimeDescargas",
            data: actionData3,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                setExtras(JSON.parse(msg.d));
            },
            error: function (result) {
                console.log(result);
            }
        });

}

function loadAnimeDetalle(id) {
    var actionData = "{'id': '" + id + "'}";
    $.ajax(
        {
            url: "detalleAnime.aspx/getAnimeDetalle",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                setDataAnimes(JSON.parse(msg.d));
            },
            error: function (result) {
                console.log(result);
            }
        });}

function setDataAnimes(array) {

    $("#titulo").text(array[0].nombre);
    $("#titulo2").text(array[0].nombre);
    $("#imagen").attr("src", "data:image/png;base64," + array[0].imagen);
    $("#genero").text(" " +array[0].generos);
    $("#productora").text(" " +array[0].productora);
    $("#sinopsis").text(array[0].sinopsis);

}
var arrayDescargas;
var arrayExtras;
function setDescargas(array) {
    arrayDescargas = array;
    $("#descargas").html("No hay descargas para este anime...");
    let html = "";
    for (let i = 0; i < array.length; i++) {
        $("#descargas").html("");
        
        html+= "<strong>" + array[i].nombre + "</strong>";
        html +="</br>";
        html += "<a href='" + array[i].link + "'>" + array[i].link + "</a><br>";        
        if (tipoUsuario !== "usuario") {
            html += "<button class='btn bg-info' onclick='editar(" + i + "," + 1 + ")'>Editar</button>";
            html += "<button class='btn bg-danger' onclick='eliminar(" + array[i].id + ")'>Eliminar</button>";
        }
        html += "</br>";
    }
    if (array.length !== 0) {
        $("#descargas").html(html);
    }
}

function editar(i, tipo) {
    
    if (tipo === 1) {        
        console.log(arrayDescargas);
        $("#txtNombre").val(arrayDescargas[i].nombre);
        $("#txtLink").val(arrayDescargas[i].link);
        $("#idEditarDescarga").val(arrayDescargas[i].id);
        $("#editDescarga").css("display", "block");
    } else {
        console.log(arrayExtras);
        $("#txtNombre2").val(arrayExtras[i].nombre);
        $("#txtLink2").val(arrayExtras[i].link);
        $("#idEditarExtra").val(arrayExtras[i].id);
        $("#editExtra").css("display", "block");
    }
}

function finalizaEditar(tipo){
    let newNombre;
    let newLink;
    let id;
    let id_anime = $("#idAnime").val();

    if (tipo === 1) {
        id = $("#idEditarDescarga").val();
        newNombre = $("#txtNombre").val();
        newLink = $("#txtLink").val();
    } else {
        id = $("#idEditarExtra").val();
        newNombre = $("#txtNombre2").val();
        newLink = $("#txtLink2").val();
    }
    var actionData4 = "{'id': '" + id + "', 'nombre':'" + newNombre + "', 'link':'" + newLink + "'}";

    $.ajax(
        {
            url: "detalleAnime.aspx/editarLink",
            data: actionData4,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                console.log(msg)
                loadAnimeExtras(id_anime);
                if (tipo === 1) {
                    $("#txtNombre").val("");
                $("#txtLink").val("");
                $("#editDescarga").css("display", "none");
            }else{
                $("#txtNombre2").val("");
                $("#txtLink2").val("");
                $("#editExtra").css("display", "none");
            }
            },
            error: function (result) {
                console.log(result);
            }
        });
}
function eliminar(id_delete) {
    let id = $("#idAnime").val();
    $("#dialog-confirm").dialog({
        resizable: false,
        height: "auto",
        width: 400,
        modal: true,
        open: function (event, ui) {
            $(".ui-dialog-titlebar-close", ui.dialog || ui).hide();
        },
        buttons: {
            "Eliminar": function () {
                var actionData = "{'id': '" + id_delete + "'}";

                $.ajax(
                    {
                        url: "detalleAnime.aspx/eliminarLink",
                        data: actionData,
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            console.log(msg)
                            if (msg.d === "true") {
                                toggleAlert();
                                loadAnimeExtras(id);
                            }
                        },
                        error: function (result) {
                            toggleAlert2()
                            console.log(result);
                        }
                    });
                $(this).dialog("close");
            },
            "Cancelar": function () {
                $(this).dialog("close");
            }
        }
    });

}

function setExtras(array) {
    arrayExtras = array;
    $("#extras").html("No hay extras para este anime...");
    let html = "";
    for (let i = 0; i < array.length; i++) {
        $("#extras").html("");

        html += "<strong>" + array[i].nombre + "</strong>";
        html += "</br>";
        html += "<a href='" + array[i].link + "'>" + array[i].link + "</a><br>";
        if (tipoUsuario !== "usuario") {
            html += "<button class='btn bg-info' onclick='editar(" + i + "," + 2 + ")'>Editar</button>";
            html += "<button class='btn bg-danger' onclick='eliminar(" + array[i].id + ")'>Eliminar</button>";
        }
        html += "</br>";
    }
    if (array.length !== 0) {
        $("#extras").html(html);
    }
}

function btnAgregar(tipo) {
    let id = $("#idAnime").val();
    let nombre;
    let link;
    if (tipo === 'descarga') {
        nombre = $("#txtNombre").val();
        link = $("#txtLink").val();
    } else {
        nombre = $("#txtNombre2").val();
        link = $("#txtLink2").val();
    }

    var actionData4 = "{'id': '" + id + "', 'nombre':'" + nombre + "', 'link':'"+link+"', 'tipo':'"+tipo+"' }";

    $.ajax(
        {
            url: "detalleAnime.aspx/agregarLink",
            data: actionData4,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                console.log(msg)                
                loadAnimeExtras(id);
                $("#txtNombre").val("");
                $("#txtLink").val("");
                $("#txtNombre2").val("");
                $("#txtLink2").val("");
            },
            error: function (result) {
                console.log(result);                
            }
        });
}