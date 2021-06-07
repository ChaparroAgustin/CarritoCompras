using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> lista = new List<Articulo>();

            conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "Select A.ID, A.Codigo, A.Nombre, A.Descripcion, M.Descripcion as Marca, M.id as IDMarca, C.Descripcion as Categoria, C.ID as IDCategoria, ImagenUrl,  Precio  from ARTICULOS A, MARCAS M, CATEGORIAS C where A.IdMarca=M.Id and A.IdCategoria=C.Id";
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo aux = new Articulo();
                aux.id = lector.GetInt32(0); //Este no funciona porque la prop es privada...
                aux.Codigo = lector.GetString(1);
                aux.Nombre = lector.GetString(2);
                aux.Descripcion = lector.GetString(3);
                aux.UrlImage = (string)lector["ImagenUrl"];
                aux.Precio = (decimal)lector["Precio"]; //aux.Precio = lector.GetDecimal(6);

                aux.Marca = new Marca();  //primero hay que instanciarlo
                aux.Marca.Descripcion = (string)lector["Marca"]; //asignas lo que obtenes del lector, primero instanciar
                aux.Marca.id = (int)lector["IDMarca"];

                aux.Categoria = new Categoria();
                aux.Categoria.Descripcion = (string)lector["Categoria"];
                aux.Categoria.id = (int)lector["IDCategoria"];

                lista.Add(aux);
            }
            conexion.Close();
            return lista;
        }

        public void modificar(Articulo articulo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "update ARTICULOS set Codigo=@codigo, Nombre=@Nombre, Descripcion=@Descripcion, idMarca=@IDMarca, idCategoria=@IDCategoria, ImagenURL=@ImagenUrl, Precio=@Precio WHERE Id=@id";
                comando.Connection = conexion;

                comando.Parameters.AddWithValue("@id", articulo.id);
                comando.Parameters.AddWithValue("@Codigo", articulo.Codigo);
                comando.Parameters.AddWithValue("@Nombre", articulo.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", articulo.Descripcion);
                comando.Parameters.AddWithValue("@idMarca", articulo.Marca.id);
                comando.Parameters.AddWithValue("@idCategoria", articulo.Categoria.id);
                comando.Parameters.AddWithValue("@ImagenUrl", articulo.UrlImage);
                comando.Parameters.AddWithValue("@Precio", articulo.Precio);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void agregar(Articulo nuevo)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "insert into ARTICULOS (Codigo,Nombre,Descripcion,IdMarca, IdCategoria, ImagenUrl, Precio) values ('" + nuevo.Codigo + "','" + nuevo.Nombre + "','" + nuevo.Descripcion + "',@idMarca,@idCategoria,@URL,@Precio)";
            //'" + nuevo.UrlImage + "'

            comando.Parameters.AddWithValue("@URL", nuevo.UrlImage);
            comando.Parameters.AddWithValue("@IdMarca", nuevo.Marca.id);
            comando.Parameters.AddWithValue("@IdCategoria", nuevo.Categoria.id);
            comando.Parameters.AddWithValue("@Precio", nuevo.Precio);

            comando.Connection = conexion;

            conexion.Open();
            comando.ExecuteNonQuery();

        }

        public void Eliminar(int id)
        {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.ConnectionString = "data source=.\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Delete From Articulos WHERE Id=@id";
                comando.Connection = conexion;

                comando.Parameters.AddWithValue("@id", id);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
