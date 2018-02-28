using System;

namespace EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades
{
    public class Servicio
    {
        public Servicio(Guid politicaId, string tiempoEstimadoEntrega, string nombre)
        {
            PoliticaId = politicaId;
            TiempoEstimadoEntrega = tiempoEstimadoEntrega;
            Nombre = nombre;
        }

        public ServicioId Id { get; set; }
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid PoliticaId { get; private set; }
        public string TiempoEstimadoEntrega { get; private set; }
        public string Nombre { get; private set; }
    }
}
