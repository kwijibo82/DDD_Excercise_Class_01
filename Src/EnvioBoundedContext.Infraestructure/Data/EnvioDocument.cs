using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using System.Collections.Generic;
using Microsoft.Azure.Documents;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;

namespace EnvioBoundedContext.Infraestructure.Data
{
    public class EnvioDocument : Resource
    {
        public string EnvioStateKey { get; set; }
        public ServicioId ServicioId { get; set; }
        public EnvioPersona Remitente { get; set; }
        public EnvioPersona Destinatario { get; set; }
        public Direccion DireccionEntrega { get; set; }
        public Direccion DireccionRecogida { get; set; }
        public IEnumerable<Bulto> Bultos { get; set; }

        internal EnvioDocument()
        {
            
        }
    }
}