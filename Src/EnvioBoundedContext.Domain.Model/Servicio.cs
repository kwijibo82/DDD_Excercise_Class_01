using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    class Servicio
    {
        // TODO: Tanto las entidades como los VO tienen propiedades readonly
        //Politica id. Primero Entidad luego sufijo 
        public Guid IDPolitica { get; set; }

        //TODO: Es solo una propiedad. TiempoEstimadoEntrega
        public string TiempoEstimadp { get; set; }
        public string TiempoEntrega { get; set; }
        public string Nombre { get; set; }
    }
}
