using Common.Domain.Model.Bases;
using System;

namespace Common.Domain.Model.EventAggregator
{
    public interface IEventAggregatorReactive : IDisposable, Bases.EventDispacher
    {
        IObservable<TEvent> GetEvent<TEvent>() where TEvent : DomainEvent;
    }
}