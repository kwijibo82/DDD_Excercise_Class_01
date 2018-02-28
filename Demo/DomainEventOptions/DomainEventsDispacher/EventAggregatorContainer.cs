using System;
using System.Collections.Generic;
using Autofac;
using DomainEventsDispacher.Bases;

namespace DomainEventsDispacher
{
    public class EventAggregatorContainer : Bases.EventDispacher
    {
        private readonly IComponentContext _container;

        public EventAggregatorContainer(IComponentContext container)
        {
            _container = container;
        }

        public void Raise<TEvent>(TEvent aEvent) where TEvent : DomainEvent
        {
            if (aEvent == null)
                throw new ArgumentNullException(nameof(aEvent), "Event can not be null.");

            foreach (var handler in _container.Resolve<IEnumerable<DomainEventHandler<TEvent>>>())
            {
                handler.Handle(aEvent);
            }
        }
    }
}