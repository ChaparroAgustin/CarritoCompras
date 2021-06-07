using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public int id { get; set; }

        public string Descripcion { get; set; }

        public Categoria(int ids, string desc)
        {
            id = ids;
            Descripcion = desc;
        }

        public Categoria() { }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
