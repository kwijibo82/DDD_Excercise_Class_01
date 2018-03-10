using System;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class BultoSnapShot
    {
        public Guid EnvioSnapShotId { get; set; }

        public Guid BultoSnapShotId { get; set; }
        public string UnidadPeso { get; set; }
        public double Peso { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
        public double Largo { get; set; }
    }
}