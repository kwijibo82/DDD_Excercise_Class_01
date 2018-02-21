using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    // TODO: public en la clase
    class Direccion
    {
        public string NombreCalle { get; }
        public string NumeroPortal { get; }
        public string Piso { get; }
        public string Puerta { get; }
        public string Escalera { get; }
        public string CodigoPostal { get; }
        public string Localidad { get; }
        public string Provincia { get; }

        // TODO: Nomenclatura y validaciones
        public Direccion(string NombreCalle, string NumeroPortal, string Piso, string Puerta, string Escalera, string CodigoPostal, string Localidad, string Provincia)
        {
            this.NombreCalle = NombreCalle;
            this.NumeroPortal = NumeroPortal;
            this.Piso = Piso;
            this.Puerta = Puerta;
            this.Escalera = Escalera;
            this.CodigoPostal = CodigoPostal;
            this.Localidad = Localidad;
            this.Provincia = Provincia;
        }

        public override int GetHashCode()
        {
            int hashCode = 17;

            hashCode = (hashCode * 23) + (NombreCalle   == null ? 0 : NombreCalle.GetHashCode());
            hashCode = (hashCode * 23) + (NumeroPortal  == null ? 0 : NumeroPortal.GetHashCode());
            hashCode = (hashCode * 23) + (Piso          == null ? 0 : Piso.GetHashCode());
            hashCode = (hashCode * 23) + (Puerta        == null ? 0 : Puerta.GetHashCode());
            hashCode = (hashCode * 23) + (Escalera      == null ? 0 : Escalera.GetHashCode());
            hashCode = (hashCode * 23) + (CodigoPostal  == null ? 0 : CodigoPostal.GetHashCode());
            hashCode = (hashCode * 23) + (Localidad     == null ? 0 : Localidad.GetHashCode());
            hashCode = (hashCode * 23) + (Provincia     == null ? 0 : Provincia.GetHashCode());

            return hashCode;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Direccion d = (Direccion)obj;
            return (NombreCalle == d.NombreCalle) && (NumeroPortal == d.NumeroPortal) && (Piso == d.Piso) && (Puerta == d.Puerta) && (Escalera == d.Escalera) && (CodigoPostal == d.CodigoPostal) && (Localidad == d.Localidad) && (Provincia == d.Provincia);
        }
    }
}
