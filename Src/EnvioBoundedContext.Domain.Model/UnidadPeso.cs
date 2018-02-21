using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO: adjustar namespace 
namespace EnvioBoundedContext.Domain
{
    // TODO : Las propiedades Clave y Valor son readonly, no privadas.
    // TODO : Aplican las mismas reglas que para un VO 
    // TODO : Agregar constructor
    // TODO : Cual es el proposito de GetClave y GetValor
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
