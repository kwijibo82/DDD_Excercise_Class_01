// TODO: adjustar namespace
namespace EnvioBoundedContext.Domain.Model
{
    public class Peso
    {
        // TODO: constructor con validaciones

        public UnidadPeso Unidad { get; private set; }
        // TODO: El peso puede ser negativo? Mirar la clase PositiveDouble https://stackoverflow.com/a/7305947
        public PositiveDouble Valor { get; private set; }

        public Peso(UnidadPeso unidad, double valor)
        {
            this.Unidad = unidad;
            this.Valor = new PositiveDouble(valor);
        }
    }

   


}
