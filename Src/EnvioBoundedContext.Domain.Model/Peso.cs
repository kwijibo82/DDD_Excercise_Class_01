using Common.Domain.Model;
using Common.Domain.Model.Domain;
using Newtonsoft.Json;

namespace EnvioBoundedContext.Domain.Model
{
    public class Peso : ValueObject<Peso>
    {
        public UnidadPeso Unidad { get; }
        public PositiveDouble Valor { get; }

        [JsonConstructor]
        public Peso(UnidadPeso unidad, PositiveDouble valor)
        {
            Unidad = unidad;
            Valor = valor;
        }
        public Peso(UnidadPeso unidad, double valor) : this(unidad, new PositiveDouble(valor))
        {

        }
    }




}
