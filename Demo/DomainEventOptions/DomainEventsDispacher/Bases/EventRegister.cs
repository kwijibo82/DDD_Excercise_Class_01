using System;

namespace DomainEventsDispacher.Bases
{
    public interface EventRegister
    {
        void RegisterHandler<TEvent>(Action<TEvent> handler) where TEvent : DomainEvent;
    }
}