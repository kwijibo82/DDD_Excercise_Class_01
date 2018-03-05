using Common.Domain.Model;


namespace EnvioBoundedContext.Domain.Model
{
    public class UnidadPeso : Enumeration
    {
        public UnidadPeso(string clave, string valor) : base(clave, valor)
        {
        }

        public static UnidadPeso Kilo = new UnidadPeso("KG", "Kilogramos");

        public static UnidadPeso Gramo = new UnidadPeso("GR", "Gramos");

    }
}
