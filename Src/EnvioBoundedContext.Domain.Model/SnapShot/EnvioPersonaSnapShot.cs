using System;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class EnvioPersonaSnapShot
    {
        // 2. Public Properties
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid EnvioPersonaSnapShotId { get; set; }

        public string Nombre { get; set; }

        public string Apellido1 { get; set; }

        public string Apellido2 { get; set; }

        public void Update(EnvioPersona nuevoRemitente)
        {
            Nombre = nuevoRemitente.Nombre;
            Apellido1 = nuevoRemitente.Apellido1;
            Apellido2 = nuevoRemitente.Apellido2;
        }
    }
}