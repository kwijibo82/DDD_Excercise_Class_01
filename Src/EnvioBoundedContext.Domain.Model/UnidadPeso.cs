using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EnvioBoundedContext.Domain.Model
{
    public class UnidadPeso : ValueObject<UnidadPeso>
    {
        public string Clave { get; }
        public string Valor { get; }

        public UnidadPeso(string clave, string valor)
        {
            Requires.NotNullOrEmpty(clave, nameof(clave));
            Requires.NotNullOrEmpty(valor, nameof(valor));

            this.Clave = clave;
            this.Valor = valor;
        }

        public static UnidadPeso Kilo = new UnidadPeso("KG", "Kilogramos");
        public static UnidadPeso Gramo = new UnidadPeso("GR", "Gramos");

    }
}
