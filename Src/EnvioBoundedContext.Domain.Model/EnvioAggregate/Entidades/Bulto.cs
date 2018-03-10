using Common.Domain.Model.Domain;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class Bulto : ValueObject<Bulto>
    {
        public Peso Peso { get; private set; }
        public Dimensiones Dimensiones { get; }

        public Bulto(Peso peso, Dimensiones dimensiones)
        {
            Peso = peso;
            Dimensiones = dimensiones;
        }

        public void CambiarPesoaKilos()
        {
            if (Equals(Peso.Unidad, UnidadPeso.Kilo))
            {
                return;
            }

            if (Equals(Peso.Unidad, UnidadPeso.Gramo))
            {
                this.Peso = new Peso(UnidadPeso.Kilo, this.Peso.Valor.Value / 1000);
            }
        }
    }
}
