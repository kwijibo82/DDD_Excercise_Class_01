using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: adjustar namespace
namespace EnvioBoundedContext.Domain.Model
{
    public class Bulto
    {
        // TODO: constructor con validaciones
        public Peso Peso { get; private set; }
        public Dimensiones Dimensiones { get; private set; }

        public Bulto(Peso peso, Dimensiones dimensiones)
        {
            this.Peso = peso;
            this.Dimensiones = dimensiones;
        }
    }
}
