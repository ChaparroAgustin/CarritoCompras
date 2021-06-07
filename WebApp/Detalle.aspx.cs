using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace WebApp
{
    public partial class Detalle : System.Web.UI.Page
    {
        public Articulo ArticuloDetalle { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloAux = new ArticuloNegocio();
            List<Articulo> listaAux;
            try
            {
                listaAux = articuloAux.listar();
                int idAux = Convert.ToInt32(Request.QueryString["idArticulo"]);
                ArticuloDetalle = listaAux.Find(Art => Art.id == idAux);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}