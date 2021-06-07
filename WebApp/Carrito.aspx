<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApp.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 id="head">CARRITO DE COMPRAS</h1>

                    <br />
                    <br />
                </div>
            </div>
        </div>
        <table class="table">
            <thead>
                <tr>
                    <th scope="col">Codigo</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Precio</th>
                </tr>
            </thead>
            <div>
                <% foreach (Dominio.Articulo item in listaCarritoCompras)
                    { %>
            <tbody>
                <tr>
                    <td><%=item.id %></td>
                    <td><%=item.Nombre %></td>
                    <td><%=item.Precio %></td>
                    <td>
                        <a href="Carrito.aspx?idArticuloEliminar=<%= item.id.ToString() %>" class="btn btn-primary" id="btnP">Eliminar del carrito</a> <%//sin to.String %>
                    </td>
                </tr>
            </tbody>

            <%  } %>
        </table>
        <div class="container-fluid">
            <div class="col-md-6">
                <h1 id="cant">Cantidad de articulos seleccionados: 
                    <asp:Label Text="" ID="lblcant" runat="server" /></h1>

            </div>
            <div class="col-md-6">
                <div class="row">
                    <h1 id="total">Total: $<asp:Label Text="" ID="lblTotal" runat="server" /></h1>
                </div>
            </div>
        </div>
    </div>
   <div> </div><br />


    <div class="col-md-12">
        <a href="Catalogo.aspx" class="btn btn-primary" id="btnP">Volver al Catalogo</a>
        <asp:Button Text="Finalizar Compra" class="btn btn-primary" ID="btnComprar" onclick="btnComprar_Click" runat="server" />
        
    </div>
    <br />
    <br />
    <br />
        

    <style>

        body {
            background-color: aquamarine;
        }

        .card{
            background-color: aquamarine;
            margin-bottom: 100px;
            height: 350px;
            border: solid 0px;
        }
        #im{
            height: 250px;
            
        }

        .col-md-12{
            text-align: center;
        }

        .content{
            padding: 10px;
        }
             
        #agre{
        font-size: 30px;
        font-weight: bold;
        font-family: Arial;
        text-align: center;
        padding: 20px;
        }

        .card .btn{
            float: right;
           
        }

         #btnP{
            border-radius: 10px;
        }

        #btnP:hover{
            background: white;
            border: solid 1px #ffe57f;
            font-size: 15px;
            color: black;
            border: solid 0.5px black;
        }

        .row{
            margin-top: 0px;
           padding-left: 160px;
            color: black;
            
        }
             
        hr {
            border: 0 none black;
            border-top: 1px solid black;
            
            display: block;
            clear: both;
            }

        #head{
            text-align: center;
            padding-right: 220px;
        }

        #cant{
            font-size: 25px;
        }
        
    </style>

</asp:Content>
