using System;
using DomainEventsDispacher.Bases;

namespace DomainEventsDispacher.Events
{
    public class AvisadoEstas : DomainEvent
    {
        public string Nombre { get; }

        public AvisadoEstas(string nombre)
        {
            Nombre = nombre;
            OccuredOn = DateTime.UtcNow;
        }

        public DateTime OccuredOn { get; }

        public override string ToString()
        {
            return $"{OccuredOn:O} : {Nombre}";
        }
    }
}