namespace EnvioBoundedContext.Domain.Model
{
    public class Direccion : ValueObject<Direccion>
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
