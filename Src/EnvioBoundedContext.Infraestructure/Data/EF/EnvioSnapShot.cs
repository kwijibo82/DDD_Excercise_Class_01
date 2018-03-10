using System;
using System.Collections.Generic;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class EnvioSnapShot
    {
        public Guid EnvioSnapShotId { get; set; }

        public Guid? ServicioId { get; set; }

        public string EnvioState { get; set; }

        public Guid RemitenteId { get; set; }
        public virtual EnvioPersonaSnapShot Remitente { get; set; }

        public Guid DestinatarioId { get; set; }
        public virtual EnvioPersonaSnapShot Destinatario { get; set; }

        public Guid DireccionEntregaId { get; set; }
        public virtual DireccionSnapShot DireccionEntrega { get; set; }

        public Guid DireccionRecogidaId { get; set; }
        public virtual DireccionSnapShot DireccionRecogida { get; set; }

        public virtual ICollection<BultoSnapShot> Bultos { get; set; }
    }
}