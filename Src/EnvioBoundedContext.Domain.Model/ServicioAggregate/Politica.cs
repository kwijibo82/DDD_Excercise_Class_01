using System;
using System.Collections.Generic;
using EnvioBoundedContext.Domain.Model;

namespace EnvioBoundedContext.Domain.Model.ServicioAggregate
{
    // TODO: agregar public
    public class Politica
    {
        public static Politica Default => new Politica(new Peso(UnidadPeso.Kilo, 25d));

        public Politica(Peso peso)
        {
            PesoMaximo = peso;
        }
        // TODO: Tanto las entidades como los VO tienen propiedades readonly
        // TODO: String???
        public Peso PesoMaximo { get; }

        public bool EsPesoValido(Peso pesoTotal)
        {
            if (pesoTotal.Unidad == PesoMaximo.Unidad)
            {
                return pesoTotal < PesoMaximo;
            }

            return pesoTotal.CambiarAGramos() < PesoMaximo.CambiarAGramos();
        }

    }
}
