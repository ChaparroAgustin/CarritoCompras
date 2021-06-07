using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace WebApp
{
    public partial class Contact : Page
    {
        private int idArticulo;
        private List<Articulo> listaArticulos = null;
        private Articulo articuloCarrito = null;
        public List<Articulo> listaCarritoCompras = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (listaCarritoCompras == null)
                {
                    listaCarritoCompras = new List<Articulo>();
                }

                if (Session["listaCarritoCompras"] == null)
                {
                    Session.Add("listaCarritoCompras", listaCarritoCompras);
                }
                if (Request.QueryString["idArticulo"] != null)
                {
                    AgregarArticulo();
                }

                if (Request.QueryString["idArticuloEliminar"] != null)
                {
                    eliminarArticulo();
                }

                listaCarritoCompras = (List<Articulo>)Session["listaCarritoCompras"];

                decimal total_precio = 0;
                int cant = 0;

                foreach (var item in listaCarritoCompras)
                {
                    total_precio += item.Precio;
                    cant++;
                }

                lblcant.Text = cant.ToString();
                lblTotal.Text = total_precio.ToString();


            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }
        public void AgregarArticulo()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
            listaCarritoCompras = (List<Articulo>)Session["listaCarritoCompras"];
            listaArticulos = negocio.listar();
            articuloCarrito = BuscarArticulo(listaArticulos, idArticulo);
            listaCarritoCompras.Add(articuloCarrito);
            Session["listaCarritoCompras"] = listaCarritoCompras;
        }

        public void eliminarArticulo()
        {
            idArticulo = Convert.ToInt32(Request.QueryString["idArticuloEliminar"]);
            listaCarritoCompras = (List<Articulo>)Session["listaCarritoCompras"];
            listaCarritoCompras.Remove(listaCarritoCompras.Find(id => idArticulo == id.id)); //expresion lambda
            Session["listaCarritoCompras"] = listaCarritoCompras;
        }
        private Articulo BuscarArticulo(List<Articulo> lista, Int32 id)
        {
            foreach (Articulo item in lista)
            {
                if (item.id == id)
                {
                    articuloCarrito = item;
                    return articuloCarrito;
                }
            }
            return articuloCarrito;
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            listaCarritoCompras.Clear();
            Response.Redirect("Home.aspx");
        }
    }
}