using System;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using System.Collections.Generic;
using Microsoft.Azure.Documents;

namespace EnvioBoundedContext.Infraestructure.Data
{
    public class EnvioDocument : Resource
    {
        public string Estado { get; set; }
        public Guid? ServicioId { get; set; }
        public EnvioPersona Remitente { get; set; }
        public EnvioPersona Destinatario { get; set; }
        public Direccion DireccionEntrega { get; set; }
        public Direccion DireccionRecogida { get; set; }
        public IEnumerable<Bulto> Bultos { get; set; }


    }
}