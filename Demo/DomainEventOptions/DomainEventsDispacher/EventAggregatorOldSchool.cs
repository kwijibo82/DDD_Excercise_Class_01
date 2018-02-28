using System;
using System.Collections.Generic;
using DomainEventsDispacher.Bases;

namespace DomainEventsDispacher
{
    public class EventAggregatorOldSchool : EventRegister, Bases.EventDispacher
    {
        private readonly Dictionary<Type, List<Action<DomainEvent>>>
            _routes = new Dictionary<Type, List<Action<DomainEvent>>>();

        public void RegisterHandler<T>(Action<T> handler) where T : DomainEvent
        {
            if (!_routes.TryGetValue(typeof(T), out var handlers))
            {
                handlers = new List<Action<DomainEvent>>();
                _routes.Add(typeof(T), handlers);
            }

            handlers.Add((x => handler((T)x)));
        }

        public void Raise<TEvent>(TEvent aEvent) where TEvent : DomainEvent
        {
            if (!_routes.TryGetValue(aEvent.GetType(), out var handlers))
            {
                return;
            }

            foreach (var handler in handlers)
            {
                handler.Invoke(aEvent);
            }
        }
    }
}