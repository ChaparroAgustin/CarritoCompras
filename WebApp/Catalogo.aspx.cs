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
    public partial class WebForm1 : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }

        public List<Articulo> listaBusqueda { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            listaArticulos = negocio.listar();
            listaBusqueda = listaArticulos.FindAll(x => x.Nombre.ToUpper().Contains(Request.Form["Buscar"].ToUpper())
                            || x.Descripcion.ToUpper().Contains(Request.Form["Buscar"].ToUpper())
                            || x.Categoria.Descripcion.ToUpper().Contains(Request.Form["Buscar"].ToUpper())
                            || x.Marca.Descripcion.ToUpper().Contains(Request.Form["Buscar"].ToUpper()));
            listaArticulos = listaBusqueda;
        }
    }
}