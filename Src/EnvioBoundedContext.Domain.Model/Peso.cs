using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain
{
    public class Peso
    {
        public UnidadPeso Unidad { get; private set; }
        public double Valor { get; private set; }
    }

}
