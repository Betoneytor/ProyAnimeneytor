var arrayAnimes;
$(document).ready(function () {

    loadDataAnimes();



    if ($("#tipoUsuarioAnime").val() !== "usuario") {
        $("#agregarAnime").css("display", "block");
    }

    if (window.File && window.FileReader && window.FileList && window.Blob) {
        document.getElementById('fileIdAnime').addEventListener('change', handleFileSelectAnime, false);
    }
    if (window.File && window.FileReader && window.FileList && window.Blob) {
        document.getElementById('fileIdAddAnime').addEventListener('change', handleFileSelectAddAnime, false);
    }

    $("#agregarAnime").click(function (evt) {
        $('#exampleModal2Anime').modal('show');

    });

});

var filtro = -1;

function filtroChange(tipo){
    filtro = tipo;
    loadDataAnimes();
    
    $("#btnFavs").attr("disabled", "false");
    $("#btnVistos").attr("disabled", "false");
    $("#btnPorVer").attr("disabled", "false");
}

function filtroClear() {
    filtro = -1;
    $("#btnFavs").removeAttr("disabled");
    $("#btnVistos").removeAttr("disabled");
    $("#btnPorVer").removeAttr("disabled");
    loadDataAnimes();
}

function loadDataAnimes() {

    var actionData = "{'filtro': '" + filtro + "'}";
    console.log(actionData);
    $("#table_id_animes > tbody").html("");
    $.ajax(
        {
            url: "listaAnimes.aspx/getAllAnime",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                setDataAnimesLista(JSON.parse(msg.d));
            },
            error: function (result) {
                console.log(result);
            }
        });
}


function finalizaAgregarAnimes() {
    let newTitle = $("#txtTituloAddAnime").val();
    let newProductora = $("#txtProductoraAddAnime").val();
    let newGenero = $("#txtGeneroAddAnime").val();
    let newDesc = $("#txtDescripcionAddAnime").val();
    let newImage = $("#base64AddAnime").val();

    var actionData = "{'titulo': '" + newTitle + "','desc': '" + newDesc + "', 'imagen':'" + newImage + "', 'productora':'" + newProductora + "', 'genero':'"+newGenero+"'}";

    $.ajax(
        {
            url: "listaAnimes.aspx/agregarAnime",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                loadDataAnimes();                
                $("#txtTituloAddAnime").val("");
                $("#txtProductoraAddAnime").val("");
                $("#txtGeneroAddAnime").val("");
                $("#txtDescripcionAddAnime").val("");
                $("#base64AddAnime").val("");                
                $('#exampleModal2Anime').modal('hide');



            },
            error: function (result) {
                console.log(result);
            }
        });
}

function setDataAnimesLista(array) {    
    let aux = 0;
    let rowAux = '';
    let tipo = $("#tipoUsuarioAnime").val();  

    arrayAnimes = array;

    for (let i = 0; i <= array.length; i++) {

        let tr = '<tr>';
        let td = '<td class="card_border">';
        let card1 = '<div class="card" style="width: 18rem; color: black;">';
        let src;
        try {
            src = 'data:image/png;base64,' + array[i].imagen;
        } catch (ex) {
            src = 'data:image/png;base64,' +'iVBORw0KGgoAAAANSUhEUgAAAQMAAADCCAMAAAB6zFdcAAAAQlBMVEX///+hoaGenp6amprHx8f39/fOzs7j4+P7+/uYmJjT09OlpaXv7+/29va6urq1tbWvr6/AwMDn5+fd3d2xsbGqqqp20Q+8AAACjklEQVR4nO3b6XLCIBSG4QQ0qzHG5f5vtY1byEaiZMY5Z97nX1ukwydSOKFRBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADq7av9hqrs1+P5wjG3mzKHX4/oY5mNt2V2vx7SxzJDBv8ZmA0/wokRmsGG3ZEBGbTIQH4GVVJfm3NYd8IzKKz5Z+ugvxKyMyiemyVzCulOdAb7917JFgHdic6g6PaLt4DuRGfQdBmE7BvJQHgGSZdBGdCd6AwO7zP0wiAy7ywRnYHzYfAOssnzxvNj2RlER9umYGJvHeho/DsI4RlEl1Nsyp13Fjw2Up5hSs+g/crf+LVo2HSuhYIMFpTvdbOaaaE+g27ZNNeZJtozuDgl6LmRKs+g6lWg7XShQXkGt34VfnpHrTuD3eBBhKmnWqnOIB09j5qsM2jOYD/xOMpO7Cg1ZXAejO80+Uhu/Do9GVSltVd3zUsmIzDH0SvVZJCV7cnIKamdZx5Oj5cENRkc7++6aZw2M0aXDbRk8Kqy28vzG/V8BsP6q5IMDt2p4HEySjzXNMygoKIkg7LL4F4sOXhvqrwny4OODJwC8+NkVM4H4EyWJxUZXHrvuk2fC6Qng96SoCGDajji6Z1BLwR30BoyuA2HvOLKVu5U1hRkMDwcruMco+VnkObfROAW28Vn8PVdRZO8uhCfwfXr+5rvypr0DJb/BHhkrz5EZzB3OFzlVVmTnUG2sB9c8DxGy85g/nC4cibcj9GiMyiC7/Dfr25IzsB/OFw3EdrKmuAMsvh+QTNMXojO4JBuQnQGm5GaQZxsp5aaQfhS0JH4/0zRBothT9B15x8577aVLP9KAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABDuD7d6G0PBTSbxAAAAAElFTkSuQmCC';
        }
        let srcfake = 'images/img.png';
        let card2 = '<img class="card-img-top" src="' + src + '" alt="Card image cap" onclick = "clickOnRowAnimes(' + array[i].id + ')">';
        let card3 = '<div class="card-body">';
        let card4 = '<h5 class="card-title" onclick = "clickOnRowAnimes(' + array[i].id + ')">' + array[i].nombre +  '</h5>';
        let card5 = '<p class="card-text"></p>';
        let editar = '<button href="#" class="btn btn-primary bg-info"  onclick="editarAnime('+i+')">Editar</button>';
        let eliminar = '<button class="btn btn-primary bg-danger" onclick="eliminarAnime(' + array[i].id +')">Eliminar</button>';
        let actions = editar + eliminar;
        let insertActions = "";
        if (tipo !== "usuario") {
            insertActions = actions;
        }
        let card6 = '</div>';
        let card7 = '</div>';
        let tdClose = '</td>';
        let trClose = '</tr>';

        if (aux === 0) {
            rowAux += tr + td + card1 + card2 + card3 + card4 + card5 + insertActions + card6 + card7 + tdClose;
            aux++;
        } else if (aux < 4) {
            rowAux += td + card1 + card2 + card3 + card4 + card5 + insertActions + card6 + card7 + tdClose;
            aux++;
        } else if (aux === 4) {
            rowAux += td + card1 + card2 + card3 + card4 + card5 + insertActions +card6 + card7 + tdClose + trClose;
            $('#table_id_animes > tbody:last-child').append(rowAux);
            aux = 0;
            rowAux = '';
        }
        if (i === array.length - 1) {
            $('#table_id_animes > tbody:last-child').append(rowAux + "</tr>");
        }
    }

}

function clickOnRowAnimes(id) {    
    $("#cargando").load("/detalleAnime.aspx", {
        id
    });
}

function editarAnime(index) {
    $("#exampleModalAnime").modal("show");
    $("#txtTituloAnime").val(arrayAnimes[index].nombre);
    $("#txtProductoraAnime").val(arrayAnimes[index].productora);
    $("#txtGeneroAnime").val(arrayAnimes[index].generos);
    $("#txtDescripcionAnime").val(arrayAnimes[index].sinopsis);
    $("#base64Anime").val(arrayAnimes[index].imagen);
    $("#idEditarAnime").val(arrayAnimes[index].id);

}

function eliminarAnime(id) {
    console.log(id);
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
                var actionData = "{'id': '" + id + "'}";

                $.ajax(
                    {
                        url: "listaAnimes.aspx/eliminarAnime",
                        data: actionData,
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            if (msg.d === "true") {
                                toggleAlert();
                                loadDataAnimes();
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

function finalizaEditarAnime() {

    let nombre = $("#txtTituloAnime").val();
    let productora = $("#txtProductoraAnime").val();
    let genero = $("#txtGeneroAnime").val();
    let sinopsis = $("#txtDescripcionAnime").val();
    let imagen = $("#base64Anime").val();
    let id = $("#idEditarAnime").val();

    var actionData = "{'id':'" + id + "', 'nombre': '" + nombre + "','productora': '" + productora + "', 'genero':'" + genero + "', 'sinopsis':'" + sinopsis + "', 'imagen':'" + imagen + "'}";
    
    $.ajax(
        {
            url: "listaAnimes.aspx/editarAnime",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                loadDataAnimes();                
                $("#exampleModalAnime").modal("hide");
            },
            error: function (result) {
                console.log(result);
            }
        }); 
}


function handleFileSelectAnime(evt) {
    var f = evt.target.files[0]; // FileList object
    var reader = new FileReader();
    // Closure to capture the file information.
    reader.onload = (function (theFile) {
        return function (e) {
            var binaryData = e.target.result;
            //Converting Binary Data to base 64
            var base64String = window.btoa(binaryData);
            //showing file converted to base64
            newImage = base64String;
            $("#base64Anime").val(base64String);
        };
    })(f);
    // Read in the image file as a data URL.
    reader.readAsBinaryString(f);
}

function handleFileSelectAddAnime(evt) {
    var f = evt.target.files[0]; // FileList object
    var reader = new FileReader();
    // Closure to capture the file information.
    reader.onload = (function (theFile) {
        return function (e) {
            var binaryData = e.target.result;
            //Converting Binary Data to base 64
            var base64String = window.btoa(binaryData);
            //showing file converted to base64
            newImage = base64String;
            $("#base64AddAnime").val(base64String);
        };
    })(f);
    // Read in the image file as a data URL.
    reader.readAsBinaryString(f);
}