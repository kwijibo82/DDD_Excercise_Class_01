using System;
using DomainEventsDispacher.Bases;
using DomainEventsDispacher.Events;

namespace DomainEventsDispacher.Listeners
{
    public class EventListener2 : DomainEventHandler<AvisadoEstas>
    {
        public void Handle(AvisadoEstas aEvent)
        {
            Console.WriteLine($"Evento capturado {aEvent} en EventListener.Handler");
        }
    }
}