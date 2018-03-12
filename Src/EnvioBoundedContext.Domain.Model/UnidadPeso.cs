using Common.Domain.Model;
using Newtonsoft.Json;


namespace EnvioBoundedContext.Domain.Model
{
    public class UnidadPeso : Enumeration
    {
        [JsonConstructor]
        public UnidadPeso(string id, string name) : base(id, name)
        {
        }

        public static UnidadPeso Kilo = new UnidadPeso("KG", "Kilogramos");

        public static UnidadPeso Gramo = new UnidadPeso("GR", "Gramos");

        public UnidadPeso()
        {

        }
    }
}
