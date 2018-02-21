using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    // TODO: public en la clase
    public class Direccion : ValueObject<Direccion>, IEquatable<Direccion>
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
            if (string.IsNullOrWhiteSpace(tipoVia)) throw new ArgumentNullException(nameof(tipoVia));
            if (string.IsNullOrWhiteSpace(nombreCalle)) throw new ArgumentNullException(nameof(nombreCalle));
            if (string.IsNullOrWhiteSpace(numeroPortal)) throw new ArgumentNullException(nameof(numeroPortal));
            if (string.IsNullOrWhiteSpace(piso)) throw new ArgumentNullException(nameof(piso));
            if (string.IsNullOrWhiteSpace(puerta)) throw new ArgumentNullException(nameof(puerta));
            if (string.IsNullOrWhiteSpace(escalera)) throw new ArgumentNullException(nameof(escalera));
            if (string.IsNullOrWhiteSpace(codigoPostal)) throw new ArgumentNullException(nameof(codigoPostal));
            if (string.IsNullOrWhiteSpace(localidad)) throw new ArgumentNullException(nameof(localidad));
            if (string.IsNullOrWhiteSpace(provincia)) throw new ArgumentNullException(nameof(provincia));

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
    }
}
