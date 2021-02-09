var arrayLocal;

$(document).ready(function () {

    
    loadData();


    $("#atras").click(function () {
        $("#cargando").load("/listadoNoticias.aspx");
    });

    $("#atras2").click(function () {        
        $("#cargando").load("/listaAnimes.aspx");
    });

    if (window.File && window.FileReader && window.FileList && window.Blob) {
        document.getElementById('fileId').addEventListener('change', handleFileSelect, false);
    }
    if (window.File && window.FileReader && window.FileList && window.Blob) {
        document.getElementById('fileIdAdd').addEventListener('change', handleFileSelectAdd, false);
    }

    if ($("#tipoUsuario").val() !== "usuario") {
        $("#agregar").css("display", "block");
    }

    $("#agregar").click(function (evt) {
        $('#exampleModal2').modal('show');

    });

});

function loadData() {
    var actionData = "{'correo': 'Hola','password': 'Mundo'}";
    $("#table_id > tbody").html("");
    console.log("loadData");
    $.ajax(
        {
            url: "listadoNoticias.aspx/getNoticias",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                setData(JSON.parse(msg.d));
            },
            error: function (result) {
                console.log(result);
            }
        }); 
}

function setData(array) {
    arrayLocal = array;

    let tipo = $("#tipoUsuario").val();    
    for (let i = 0; i <= array.length; i++) {

        let trO = '<tr style="cursor:pointer" >';
        let tdO = '<td class="td_border" onclick = "clickOnRowNt(' + i +')">';
        let tdOImg = '<td class="td_border widthTd" onclick = "clickOnRowNt(' + i +')">';
        let tdC = '</td>';
        let trC = '</tr>';

        let src = 'data:image/png;base64,' + array[i].imagen;
        let image = '<img width="120px" heigth="120px"  src = "' + src + '"/>';

        let cont = array[i].titulo;
        let title = '<h4>' + cont + '<h4>';
        let espa = '<br></br>';
        let desc = array[i].descripcion.substring(0,50) + "...";

        let info = '<h6>' + title +'<h6>'+ espa + desc;

        let acciones = "<td style='width:20%'></td>";

        if (tipo !== "usuario") {
            let onclick = 'onclick = "editar('+i+')"';
            acciones = '<td style="width: 20 % ">' +'<button class =" btn btn-warning bg-warning"  '+onclick+' >';
            acciones += 'Editar</button>';
            acciones += '<br><br><button onclick="eliminar(' + array[i].id + ')" class="btn  btn-danger bg-danger">Eliminar</button>' + tdC;
        }

        let row = trO + tdOImg + image + tdC + tdO + info + tdC + acciones + trC;

        

        $('#table_id > tbody:last-child').append(row);
    }
}

function clickOnRowNt(i) {
    
    let titulo = arrayLocal[i].titulo;
    let descripcion = arrayLocal[i].descripcion;
    let imagen = arrayLocal[i].imagen;
    
    $("#cargando").load("/detalleNoticia.aspx", {
        titulo, descripcion, imagen
    });
}


function editar(i) {    
    $('#exampleModal').modal('show');
    let id = arrayLocal[i].id;
    let titulo = arrayLocal[i].titulo;
    let descripcion = arrayLocal[i].descripcion;
    let imagen = arrayLocal[i].imagen;

    
    $("#txtDescripcion").val(descripcion);
    $("#txtTitulo").val(titulo);
    $("#base64").val(imagen);
    $("#idEditar").val(id);

    
}
function finalizaEditar() {
    let newTitle = $("#txtTitulo").val();
    let newDesc = $("#txtDescripcion").val();
    let newImage = $("#base64").val();
    let id = $("#idEditar").val();
    var actionData = "{'id':"+id+",'titulo': '" + newTitle + "','desc': '" + newDesc + "', 'imagen':'" + newImage + "'}";
    console.log(newDesc);
    $.ajax(
        {
            url: "listadoNoticias.aspx/editarNoticia",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                loadData();
                $('#exampleModal').modal('hide');

            },
            error: function (result) {
                console.log(result);
            }
        }); 
}

function finalizaAgregar() {
    let newTitle = $("#txtTituloAdd").val();
    let newDesc = $("#txtDescripcionAdd").val();
    let newImage = $("#base64Add").val();
    
    var actionData = "{'titulo': '" + newTitle + "','desc': '" + newDesc + "', 'imagen':'" + newImage + "'}";
    
    $.ajax(
        {
            url: "listadoNoticias.aspx/agregarNoticia",
            data: actionData,
            dataType: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (msg) {
                loadData();                
                $("#txtTituloAdd").val("");
                $("#txtDescripcionAdd").val("");
                $("#base64Add").val("");
                $('#exampleModal2').modal('hide');

            },
            error: function (result) {
                console.log(result);
            }
        });
}

function handleFileSelect(evt) {
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
            $("#base64").val(base64String);
        };
    })(f);
    // Read in the image file as a data URL.
    reader.readAsBinaryString(f);
}

function handleFileSelectAdd(evt) {
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
            $("#base64Add").val(base64String);
        };
    })(f);
    // Read in the image file as a data URL.
    reader.readAsBinaryString(f);
}


function eliminar(id) {

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
                        url: "listadoNoticias.aspx/eliminarNoticia",
                        data: actionData,
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (msg) {
                            if (msg.d === "true") {
                                toggleAlert();
                                loadData();
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

function toggleAlert() {
    $("#terminado").toggleClass('in out');
    setTimeout(function () {
        $("#terminado").toggleClass('out in');
    }, 3000)
    return false; // Keep close.bs.alert event from removing from DOM
}

function toggleAlert2() {
    $("#eliminar").toggleClass('in out');
    setTimeout(function () {
        $("#eliminar").toggleClass('out in');
    }, 3000)
    return false; // Keep close.bs.alert event from removing from DOM
}