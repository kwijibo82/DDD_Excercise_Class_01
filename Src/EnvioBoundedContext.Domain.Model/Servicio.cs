using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    class Servicio
    {
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid PoliticaID { get; }
        private static string TiempoEstimadoEntrega { get; }
        public string Nombre { get; }
    }
}
