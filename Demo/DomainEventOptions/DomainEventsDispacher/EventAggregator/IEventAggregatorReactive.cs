using System;
using DomainEventsDispacher.Bases;

namespace DomainEventsDispacher.EventAggregator
{
    public interface IEventAggregatorReactive : IDisposable, Bases.EventDispacher
    {
        IObservable<TEvent> GetEvent<TEvent>() where TEvent : DomainEvent;
    }
}