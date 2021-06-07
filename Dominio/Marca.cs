using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
        public class Marca
        {
            public int id { get; set; }

            public string Descripcion { get; set; }

            public Marca(int ids, string desc)
            {
                id = ids;
                Descripcion = desc;
            }

            public Marca() { }

            public override string ToString()//para que devuelva la descripción
            {
                return Descripcion;
            }
        }
}
