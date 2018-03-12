using Common.Domain.Model;
using Common.Domain.Model.Domain;
using Newtonsoft.Json;

namespace EnvioBoundedContext.Domain.Model
{
    public class Dimensiones : ValueObject<Dimensiones>
    {
        public PositiveDouble Alto { get; }
        public PositiveDouble Ancho { get; }
        public PositiveDouble Largo { get; }

        [JsonConstructor]
        public Dimensiones(PositiveDouble alto, PositiveDouble ancho, PositiveDouble largo)
        {
            Alto = new PositiveDouble(alto);
            Ancho = new PositiveDouble(ancho);
            Largo = new PositiveDouble(largo);
        }

        public Dimensiones(double alto, double ancho, double largo) : this(new PositiveDouble(alto), new PositiveDouble(ancho), new PositiveDouble(largo))
        {
        }
    }


}
