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

        public static Peso operator +(Peso left, Peso right)
        {
            if (Equals(left.Unidad, right.Unidad))
            {
                return new Peso(left.Unidad, left.Valor.Value + right.Valor.Value);
            }
            return new Peso(UnidadPeso.Gramo, 0d);
        }

        public static bool operator <(Peso left, Peso right)
        {
            if (Equals(left.Unidad, right.Unidad))
            {
                return left.Valor.Value < right.Valor.Value;
            }

            return false;
        }

        public static bool operator >(Peso left, Peso right)
        {
            if (Equals(left.Unidad, right.Unidad))
            {
                return left.Valor.Value > right.Valor.Value;
            }

            return false;
        }

        public Peso CambiarAGramos()
        {
            return Equals(Unidad, UnidadPeso.Gramo) ? this : new Peso(UnidadPeso.Gramo, this.Valor.Value * 1000);
        }
    }




}
