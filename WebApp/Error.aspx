<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApp.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

     <div class="jumbotron jumbotron-fluid">
        <div class="container">
            <h1 class="display-4">Pagina No Encontrada</h1>
            <p class="lead">Presione "HOME" o "Catalogo" para volver.</p>
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
