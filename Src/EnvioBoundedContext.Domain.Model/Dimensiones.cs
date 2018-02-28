using Common.Domain.Model;
using Common.Domain.Model.Domain;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;

namespace EnvioBoundedContext.Domain.Model
{
    public class Dimensiones : ValueObject<Direccion>
    {
        // TODO: constructor con validaciones
        public PositiveDouble Alto { get; private set; }
        public PositiveDouble Ancho { get; private set; }
        public PositiveDouble Largo { get; private set; }

        public Dimensiones(double alto, double ancho, double largo)
        {
            this.Alto = new PositiveDouble(alto);
            this.Ancho = new PositiveDouble(ancho);
            this.Largo = new PositiveDouble(largo);
        }
    }


}
