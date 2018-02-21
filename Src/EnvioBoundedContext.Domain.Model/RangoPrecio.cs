using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    class RangoPrecio
    {
        // TODO: Tanto las entidades como los VO tienen propiedades readonly
        // TODO: Faltan validaciones
        public decimal From { get; set; }
        public decimal Hasta { get; set; }
    }
}
