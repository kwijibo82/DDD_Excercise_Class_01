using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: adjustar namespace
namespace EnvioBoundedContext.Domain
{
    public class Dimensiones
    {
        // TODO: constructor con validaciones
        public double Alto { get; private set; }
        public double Ancho { get; private set; }
        public double Largo { get; private set; }
    }
}
