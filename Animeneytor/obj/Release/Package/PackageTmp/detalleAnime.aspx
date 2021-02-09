<%@ Page Title="" Language="C#" MasterPageFile="~/Simple.Master" AutoEventWireup="true" CodeBehind="detalleAnime.aspx.cs" Inherits="Animeneytor.detalleAnime" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" charset="utf8" src="/JS/detalleAnime.js"></script>
         <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
      <link rel="stylesheet" href="CSS/jquery-ui.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <input type="hidden" value="<%=  Request.Form["id"].ToString() %>" id="idAnime"/>
    <input type="hidden" id="tipoUsuarioAnimeDetalle" value="<%=Server.HtmlEncode(Session["tipoUsuario"].ToString())%>"/>
    <h6 style="cursor:pointer;" id="atras2" class="link"><img  src="images/back.svg" width="20px" />&nbsp; Atras</h6>

    <div class="container" style="margin-bottom:20%;color:black;">
      <div class="row" style="padding: 0px;margin: 0px;">
         <div class="col-sm">
         <div class="jumbotron" style="color:black;margin:0px">
          <h1 class="display-4"><span id="titulo"></span></h1>
          <p class="lead">
              <img src="data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAQMAAADCCAMAAAB6zFdcAAAAQlBMVEX///+hoaGenp6amprHx8f39/fOzs7j4+P7+/uYmJjT09OlpaXv7+/29va6urq1tbWvr6/AwMDn5+fd3d2xsbGqqqp20Q+8AAACjklEQVR4nO3b6XLCIBSG4QQ0qzHG5f5vtY1byEaiZMY5Z97nX1ukwydSOKFRBAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAADq7av9hqrs1+P5wjG3mzKHX4/oY5mNt2V2vx7SxzJDBv8ZmA0/wokRmsGG3ZEBGbTIQH4GVVJfm3NYd8IzKKz5Z+ugvxKyMyiemyVzCulOdAb7917JFgHdic6g6PaLt4DuRGfQdBmE7BvJQHgGSZdBGdCd6AwO7zP0wiAy7ywRnYHzYfAOssnzxvNj2RlER9umYGJvHeho/DsI4RlEl1Nsyp13Fjw2Up5hSs+g/crf+LVo2HSuhYIMFpTvdbOaaaE+g27ZNNeZJtozuDgl6LmRKs+g6lWg7XShQXkGt34VfnpHrTuD3eBBhKmnWqnOIB09j5qsM2jOYD/xOMpO7Cg1ZXAejO80+Uhu/Do9GVSltVd3zUsmIzDH0SvVZJCV7cnIKamdZx5Oj5cENRkc7++6aZw2M0aXDbRk8Kqy28vzG/V8BsP6q5IMDt2p4HEySjzXNMygoKIkg7LL4F4sOXhvqrwny4OODJwC8+NkVM4H4EyWJxUZXHrvuk2fC6Qng96SoCGDajji6Z1BLwR30BoyuA2HvOLKVu5U1hRkMDwcruMco+VnkObfROAW28Vn8PVdRZO8uhCfwfXr+5rvypr0DJb/BHhkrz5EZzB3OFzlVVmTnUG2sB9c8DxGy85g/nC4cibcj9GiMyiC7/Dfr25IzsB/OFw3EdrKmuAMsvh+QTNMXojO4JBuQnQGm5GaQZxsp5aaQfhS0JH4/0zRBothT9B15x8577aVLP9KAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABDuD7d6G0PBTSbxAAAAAElFTkSuQmCC" id="imagen" width="250px"/>
              <br />
              Informacion Tecnica
          </p>          
          <p>            
            <br />
            Productora:<span id="productora"></span>
            <br />
            Genero:<span id="genero"></span>
            <br />
          </p>          
        </div>  
       </div>
      </div>
      <div class="row" style="margin-left:10px;margin-right:10px">
        <div class="col-sm">
          <div class="btn-group btn-group-lg" role="group" aria-label="Basic example" style="width: 100%;margin-left: 12%;">
              <button type="button" class="btn btn-secondary bg-secondary" id="favorito">Marcar Favorito</button>
              <button type="button" class="btn btn-secondary bg-secondary" id="visto">Marcar Visto</button>
              <button type="button" class="btn btn-secondary bg-secondary" id="porVer">Marcar Por Ver</button>
            </div>
        </div>       
      </div>
        <div class="row">
        <div class="col-sm">
          <div class="card text-center">
              <div class="card-header">
                Sinopsis
              </div>
              <div class="card-body">
                <h5 class="card-title"><span id="titulo2"></span></h5>
                <p class="card-text"><span id="sinopsis"></span></p>                
              </div>              
            </div>
        </div>      
      </div>
        <div class="row">
        <div class="col-sm">
          <div class="row">
              <div class="col-sm-6">
                <div class="card">
                  <div class="card-body">
                    <h5 class="card-title">Descargas</h5>

                     <div class="input-group" id="formDescargas">
                      <div class="input-group-prepend">
                        <button class="input-group-text" onclick="btnAgregar('descarga')">Agregar</button>
                          <button class="input-group-text"  style="display:none" id="editDescarga" onclick="finalizaEditar(1)">Editar</button>
                          <input type="hidden" id="idEditarDescarga"/>
                      </div>
                      <input type="text" style="color:black" id="txtNombre" placeholder="Nombre" class="form-control">
                      <input type="text" style="color:black" id="txtLink" placeholder="URL" class="form-control">
                    </div>
                    <p class="card-text" id="descargas"></p>                   
                  </div>
                </div>
              </div>
              <div class="col-sm-6">
                <div class="card">
                  <div class="card-body">
                    <h5 class="card-title">Extras</h5>
                      <div class="input-group" id="formExtras">
                      <div class="input-group-prepend">
                        <button class="input-group-text" onclick="btnAgregar('extra')" id="">Agregar</button>
                        <button class="input-group-text" style="display:none" id="editExtra" onclick="finalizaEditar(2)">Editar</button>
                          <input type="hidden" id="idEditarExtra"/>
                      </div>
                      <input type="text" style="color:black"  id="txtNombre2" placeholder="Nombre" class="form-control">
                      <input type="text" style="color:black" id="txtLink2" placeholder="URL" class="form-control">
                    </div>
                    <p class="card-text" id="extras"></p>                    
                  </div>
                </div>
              </div>
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


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
