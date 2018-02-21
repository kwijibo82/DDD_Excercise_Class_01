namespace EnvioBoundedContext.Domain.Model
{

    public class UnidadPeso
    {
        public static UnidadPeso Kilo = new UnidadPeso("KG", "Kilogramos");
        public static UnidadPeso Gramo = new UnidadPeso("GR", "Gramos");

        public string Clave { get; }
        public string Valor { get; }

        public UnidadPeso(string clave, string valor)
        {
            Requires.NotNullOrEmpty(clave, nameof(clave));
            Requires.NotNullOrEmpty(valor, nameof(valor));

            this.Clave = clave;
            this.Valor = valor;
        }

    }
}
