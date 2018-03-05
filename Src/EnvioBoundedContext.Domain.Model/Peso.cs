using Common.Domain.Model;
using Common.Domain.Model.Domain;

namespace EnvioBoundedContext.Domain.Model
{
    public class Peso : ValueObject<Peso>
    {
        public UnidadPeso Unidad { get; private set; }
        public PositiveDouble Valor { get; private set; }

        public Peso(UnidadPeso unidad, double valor)
        {
            this.Unidad = unidad;
            this.Valor = new PositiveDouble(valor);
        }
    }




}
