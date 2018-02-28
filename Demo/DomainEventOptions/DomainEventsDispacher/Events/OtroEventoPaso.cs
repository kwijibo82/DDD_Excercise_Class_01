using System;
using DomainEventsDispacher.Bases;

namespace DomainEventsDispacher.Events
{
    public class OtroEventoPaso : DomainEvent
    {
        public OtroEventoPaso()
        {
            OccuredOn = DateTime.UtcNow;
        }

        public DateTime OccuredOn { get; }

        public override string ToString()
        {
            return $"{OccuredOn:O}";
        }
    }
}