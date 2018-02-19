using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain
{
    public class UnidadPeso
    {
        private string Clave { get; set; }
        private string Valor { get; set; }

        public static UnidadPeso KG = new UnidadPeso{ Clave = "kgs", Valor = "kilogramo" };
        public static UnidadPeso GR = new UnidadPeso { Clave = "grs", Valor = "gramo" };

        public static string GetClave(UnidadPeso unidad)
        {
            return unidad.Clave;
        }

        public static string GetValor(UnidadPeso unidad)
        {
            return unidad.Valor;
        }
    }
}
