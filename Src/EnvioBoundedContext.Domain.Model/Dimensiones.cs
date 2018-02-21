using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: adjustar namespace
namespace EnvioBoundedContext.Domain.Model
{
    public class Dimensiones
    {
        // TODO: constructor con validaciones
        public PositiveDouble Alto { get; private set; }
        public PositiveDouble Ancho { get; private set; }
        public PositiveDouble Largo { get; private set; }

        public Dimensiones(double alto, double ancho, double largo)
        {
            this.Alto = new PositiveDouble(alto);
            this.Ancho = new PositiveDouble(alto);
            this.Largo = new PositiveDouble(alto);
        }

        
    }

  
}
