using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    class Servicio
    {
        public Guid IDPolitica { get; set; }
        public string TiempoEstimadp { get; set; }
        public string TiempoEntrega { get; set; }
        public string Nombre { get; set; }
    }
}
