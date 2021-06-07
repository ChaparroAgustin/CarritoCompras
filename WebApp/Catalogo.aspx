<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="WebApp.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="col-md-12">
    <p><input type="search" name = "Buscar" placeholder="Buscar producto">
        
                    <asp:Button Text="Buscar" ID="btnBuscar" onclick="btnBuscar_Click"  runat="server" />
        </p>
        </div>    
        
      
    <section>
        <div class="container"> 
            <div class="row">
                <div class="col-md-12">
                    <h1>CATALOGO 2020</h1>
                </div>
            </div>
            <div class="row">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                    <p id="agre">DISFRUTA DE NUESTRAS OFERTAS!</p>
                </div>
            </div>
            <div class="row">
          <% foreach (Dominio.Articulo item in listaArticulos)
            { %>
                    <div class="col-md-4">
                        <div class="card">
                            <div class="pic">
                                <a href="Detalle.aspx?idArticulo=<% = item.id.ToString() %>">
                                    <img src="<%= item.UrlImage %>" class="img" id="im" alt="...">
                                    </a>  
                                 </div>
                            <div class="content">
                                <h3><% = item.Nombre %></h3>
                                <h4><% = "Precio: $" + item.Precio %></h4>
                                <hr />
                                <img src="https://image.flaticon.com/icons/png/512/23/23258.png" id="icono"/>
                                <a href="Carrito.aspx?idArticulo=<% = item.id.ToString() %>" class="btn btn-primary" id="btnP">Agregar al carrito</a>
                                <a href="Detalle.aspx?idArticulo=<% = item.id.ToString() %>" class="btn btn-secondary" id="btnS">Ver detalle</a>

                            </div>
                                
                           
                        </div>
                         </div>                      
            
           <%  } %>
        </div>
        </section>
    
   
    <style>
        

        container{
            
        }
        body {
            background-color: aquamarine;
        }

        .card{
            background-color: aquamarine;
            margin-bottom: 100px;
            height: 450px;
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

        #btnS{
            background: black;
            border-radius: 10px;
        }

        #btnS:hover{
            background: white;
            border: solid 1px #ffe57f;
            font-size: 15px;
            border: solid 0.5px black;
        }

        #icono{
           height: 34px;
           margin-left: 20px;
        }

        hr {
            border: 0 none black;
            border-top: 1px solid black;
            
            display: block;
            clear: both;
            }
        
      

    </style>

</asp:Content>
