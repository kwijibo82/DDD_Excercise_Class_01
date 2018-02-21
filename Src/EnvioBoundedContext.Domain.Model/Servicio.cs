using System;

namespace EnvioBoundedContext.Domain.Model
{
    public class Servicio
    {
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid PoliticaId { get; private set; }
        public string TiempoEstimadoEntrega { get; private set; }
        public string Nombre { get; private set; }
    }
}
