<%@ Page Title="" Language="C#" MasterPageFile="~/Simple.Master" AutoEventWireup="true" CodeBehind="detalleNoticia.aspx.cs" Inherits="Animeneytor.detalleNoticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <h6 style="cursor:pointer;" id="atras" class="link"><img  src="images/back.svg" width="20px" />&nbsp; Atras</h6>
    <center>
        <img src="data:image/png;base64,<%=  Request.Form["imagen"].ToString() %>" width="300px" height="300px"/>
    </center>
    <hr />
    <div style="margin-bottom: 16%;">
        <hr />
        <h2><%=  Request.Form["titulo"].ToString() %></h2>
        <hr />
        <p>
            <%=  Request.Form["descripcion"].ToString() %>
        </p>
        <hr />
    </div>
    <hr />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
