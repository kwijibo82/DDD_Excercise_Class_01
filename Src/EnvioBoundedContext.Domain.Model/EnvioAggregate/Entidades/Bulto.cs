using Common.Domain.Model.Domain;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class Bulto : ValueObject<Bulto>
    {
        public Peso Peso { get; }
        public Dimensiones Dimensiones { get; }

        public Bulto(Peso peso, Dimensiones dimensiones)
        {
            Peso = peso;
            Dimensiones = dimensiones;
        }
    }
}
