using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    // TODO: public en la clase
    public class Direccion : IEquatable<Direccion>
    {
        public string TipoVia { get; }
        public string NombreCalle { get; }
        public string NumeroPortal { get; }
        public string Piso { get; }
        public string Puerta { get; }
        public string Escalera { get; }
        public string CodigoPostal { get; }
        public string Localidad { get; }
        public string Provincia { get; }

        // TODO: Nomenclatura y validaciones
        public Direccion(string tipoVia, string nombreCalle, string numeroPortal, string piso, string puerta, string escalera, string codigoPostal, string localidad, string provincia)
        {
            if (string.IsNullOrWhiteSpace(tipoVia)) throw new Exception("El tipo via es incorrecto");
            if (string.IsNullOrWhiteSpace(nombreCalle)) throw new Exception("El nombre calle es incorrecto");
            if (string.IsNullOrWhiteSpace(numeroPortal)) throw new Exception("El número portal es incorrecto");
            if (string.IsNullOrWhiteSpace(piso)) throw new Exception("El piso es incorrecto");
            if (string.IsNullOrWhiteSpace(puerta)) throw new Exception("La puerta es incorrecta");
            if (string.IsNullOrWhiteSpace(escalera)) throw new Exception("La escalera es incorrrecta");
            if (string.IsNullOrWhiteSpace(codigoPostal)) throw new Exception("El código postal es incorrecto");
            if (string.IsNullOrWhiteSpace(localidad)) throw new Exception("La localidad es incorrecta");
            if (string.IsNullOrWhiteSpace(provincia)) throw new Exception("La provincia es incorrecta");

            this.TipoVia = tipoVia;
            this.NombreCalle = nombreCalle;
            this.NumeroPortal = numeroPortal;
            this.Piso = piso;
            this.Puerta = puerta;
            this.Escalera = escalera;
            this.CodigoPostal = codigoPostal;
            this.Localidad = localidad;
            this.Provincia = provincia;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Direccion)obj);
        }

        public bool Equals(Direccion other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(TipoVia, other.TipoVia, StringComparison.InvariantCulture)
                   && string.Equals(NombreCalle, other.NombreCalle, StringComparison.InvariantCulture) && string.Equals(NumeroPortal, other.NumeroPortal, StringComparison.InvariantCulture) && string.Equals(Piso, other.Piso, StringComparison.InvariantCulture) && string.Equals(Puerta, other.Puerta, StringComparison.InvariantCulture) && string.Equals(Escalera, other.Escalera, StringComparison.InvariantCulture) && string.Equals(CodigoPostal, other.CodigoPostal, StringComparison.InvariantCulture) && string.Equals(Localidad, other.Localidad, StringComparison.InvariantCulture) && string.Equals(Provincia, other.Provincia, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = StringComparer.InvariantCulture.GetHashCode(TipoVia);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(NombreCalle);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(NumeroPortal);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(Piso);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(Puerta);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(Escalera);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(CodigoPostal);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(Localidad);
                hashCode = (hashCode * 397) ^ StringComparer.InvariantCulture.GetHashCode(Provincia);
                return hashCode;
            }
        }

        public static bool operator ==(Direccion left, Direccion right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Direccion left, Direccion right)
        {
            return !Equals(left, right);
        }
    }
}
