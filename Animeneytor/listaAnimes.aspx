<%@ Page Title="" Language="C#" MasterPageFile="~/Simple.Master" AutoEventWireup="true" CodeBehind="listaAnimes.aspx.cs" Inherits="Animeneytor.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
      <link rel="stylesheet" href="CSS/jquery-ui.css">
    <link rel="stylesheet" href="/CSS/animes.css">
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js" integrity="sha384-Tc5IQib027qvyjSMfHjOMaLkfuWVxZxUPnCJA7l2mCWNIpG9mGCD8wGNIcPD7Txa" crossorigin="anonymous"></script>

     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <input type="hidden" id="tipoUsuarioAnime" value="<%=Server.HtmlEncode(Session["tipoUsuario"].ToString())%>"/>
    <button class="btn btn-success m-2" id="agregarAnime" style="display:none" >Agregar</button>
  
<div class="btn-group" role="group" aria-label="Basic example">
  <button type="button" class="btn btn-secondary bg-primary" id="btnFavs" onclick="filtroChange(1)">Favoritos</button>
  <button type="button" class="btn btn-secondary bg-primary" id="btnVistos" onclick="filtroChange(2)">Vistos</button>
  <button type="button" class="btn btn-secondary bg-primary" id="btnPorVer" onclick="filtroChange(3)">Por Ver</button>
  <button type="button" class="btn btn-secondary bg-primary" onclick="filtroClear()">Limpiar Filtros</button>
</div>
    
    <table id="table_id_animes" class="display" style="width:100%;margin-bottom: 100px;" cellpadding="0" cellspacing ="0">        
        <tbody>
        </tbody>
    </table>


    <!-- Modal -->
<div class="modal fade" id="exampleModalAnime" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document" style="position: fixed;left: 30%;color:black;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Editar</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="row">
            <div class="col-md-12">
                <input type="text" id="txtTituloAnime" class="form-control" style="color:black" placeholder="Titulo"/>
                <input type="text" id="txtProductoraAnime" class="form-control" style="color:black" placeholder="Productora"/>
                <input type="text" id="txtGeneroAnime" class="form-control" style="color:black" placeholder="Genero"/>                
                <input type="hidden" id="base64Anime" class="form-control" style="color:black" placeholder="Titulo"/>
                <input type="hidden" id="idEditarAnime" class="form-control" style="color:black" placeholder="Titulo"/>                
            </div>
            <div class="col-md-12">
                <textarea placeholder="Descripcion" id="txtDescripcionAnime" style="margin-top: 0px;margin-bottom: 0px;height: 100px;">

                </textarea>
            </div>
            <br />
            <div class="col-md-12 mt-3">
                  <div class="custom-file">
                    <input type="file" id="fileIdAnime" class="custom-file-input" id="validatedCustomFile" required>
                    <label class="custom-file-label" for="validatedCustomFile">Buscar Imagen</label>
                    <div class="invalid-feedback">archivo no valido</div>
                  </div>
            </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
        <button type="button" class="btn btn-success" onclick="finalizaEditarAnime()">Editar</button>
      </div>
    </div>
  </div>
</div>

    <!-- Modal -->
<div class="modal fade" id="exampleModal2Anime" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document" style="position: fixed;left: 30%;color:black;">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Agregar</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
        <div class="row">
            <div class="col-md-12">
                <input type="text" id="txtTituloAddAnime" class="form-control" style="color:black" placeholder="Titulo"/>
                <input type="text" id="txtProductoraAddAnime" class="form-control" style="color:black" placeholder="Productora"/>
                <input type="text" id="txtGeneroAddAnime" class="form-control" style="color:black" placeholder="Genero"/>                
                <input type="hidden" id="base64AddAnime" class="form-control" style="color:black" placeholder="Titulo"/>
                <input type="hidden" id="idEditarAddAnime" class="form-control" style="color:black" placeholder="Titulo"/>
            </div>
            <div class="col-md-12">
                <textarea placeholder="Descripcion" id="txtDescripcionAddAnime" style="margin-top: 0px;margin-bottom: 0px;height: 100px;">

                </textarea>
            </div>
            <br />
            <div class="col-md-12 mt-3">
                  <div class="custom-file">
                    <input type="file" id="fileIdAddAnime" class="custom-file-input" required>
                    <label class="custom-file-label" for="fileIdAddAnime">Buscar Imagen</label>
                    <div class="invalid-feedback">archivo no valido</div>
                  </div>
            </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>
        <button type="button" class="btn btn-success" onclick="finalizaAgregarAnimes()">Agregar</button>
      </div>
    </div>
  </div>
</div>

        <div id="dialog-confirm" title="Eliminar" style="display:none">
      <p><span class="ui-icon ui-icon-alert" style="float:left; margin:12px 12px 20px 0;"></span>¿Estas seguro que deseas eliminar el registro?</p>
    </div>
    <div id="terminado" class="alert alert-success fade out" style="width: 40%;position: absolute;right: 0;bottom: 12%;">
      <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
      <strong>Terminado!</strong> Se ha eliminado correctamente
    </div>
     <div id="eliminar" class="alert alert-danger fade out" style="width: 40%;position: absolute;right: 0;bottom: 12%;">
      <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
      <strong>Error!</strong> No se pudo eliminar
    </div>

    <div class="alert alert-danger fade out" id="bsalertError">
  <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
  <strong>Error!</strong> Ocurrio un error intenta mas tarde
</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
