<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="jumbotron-fluid">
            <h1 class="display-4"><% = ArticuloDetalle.Nombre %></h1>
            <p class="lead">Precio Unitario: <% = ArticuloDetalle.Precio %></p>
            <img src="<%= ArticuloDetalle.UrlImage %>" class="img" alt="..." />
            <hr class="my-4">
            <p id="detalle"><% = ArticuloDetalle.Descripcion %></p>
            <p class="lead">
                <a class="btn btn-primary btn-lg" href="Catalogo" role="button">volver...</a>
            </p>
        </div>
    </div>




    <style>
        body {
            background-color: aquamarine;
        }

        img{

            width: 500px;
        }
        .container{
           text-align: center;


        }

        #detalle{
        font-size: 30px;
        font-weight: bold;
        font-family: Arial;
        text-align: center;
        padding: 20px;
        }

    </style>

</asp:Content>
