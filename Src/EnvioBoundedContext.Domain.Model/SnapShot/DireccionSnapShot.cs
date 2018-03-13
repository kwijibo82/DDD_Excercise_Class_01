using System;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class DireccionSnapShot
    {
        public Guid DireccionSnapShotId { get; set; }
        public string TipoVia { get; set; }
        public string NombreCalle { get; set; }
        public string NumeroPortal { get; set; }
        public string Piso { get; set; }
        public string Puerta { get; set; }
        public string Escalera { get; set; }
        public string CodigoPostal { get; set; }
        public string Localidad { get; set; }
        public string Provincia { get; set; }
    }
}