// TODO: adjustar namespace
namespace EnvioBoundedContext.Domain.Model
{
    public class Bulto
    {
        public Peso Peso { get; private set; }
        public Dimensiones Dimensiones { get; private set; }

        public Bulto(Peso peso, Dimensiones dimensiones)
        {
            this.Peso = peso;
            this.Dimensiones = dimensiones;
        }
    }
}
