namespace EnvioBoundedContext.Domain.Model
{
    public class Direccion : ValueObject<Direccion>
    {
        public string TipoVia { get; private set; }
        public string NombreCalle { get; private set; }
        public string NumeroPortal { get; private set; }
        public string Piso { get; private set; }
        public string Puerta { get; private set; }
        public string Escalera { get; private set; }
        public string CodigoPostal { get; private set; }
        public string Localidad { get; private set; }
        public string Provincia { get; private set; }


        public Direccion(string tipoVia, string nombreCalle, string numeroPortal, string piso, string puerta, string escalera, string codigoPostal, string localidad, string provincia)
        {
            Requires.NotNullOrEmpty(tipoVia, nameof(tipoVia));
            Requires.NotNullOrEmpty(nombreCalle, nameof(nombreCalle));
            Requires.NotNullOrEmpty(numeroPortal, nameof(numeroPortal));
            Requires.NotNullOrEmpty(piso, nameof(piso));
            Requires.NotNullOrEmpty(puerta, nameof(puerta));
            Requires.NotNullOrEmpty(escalera, nameof(escalera));
            Requires.NotNullOrEmpty(codigoPostal, nameof(codigoPostal));
            Requires.NotNullOrEmpty(localidad, nameof(localidad));
            Requires.NotNullOrEmpty(provincia, nameof(provincia));

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
