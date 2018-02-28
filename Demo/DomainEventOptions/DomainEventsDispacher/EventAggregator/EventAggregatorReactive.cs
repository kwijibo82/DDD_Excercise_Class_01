using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using DomainEventsDispacher.Bases;

namespace DomainEventsDispacher.EventAggregator
{
    public class EventAggregatorReactive : IEventAggregatorReactive
    {
        readonly Subject<DomainEvent> subject = new Subject<DomainEvent>();

        public IObservable<TEvent> GetEvent<TEvent>() where TEvent : DomainEvent
        {
            return subject.OfType<TEvent>().AsObservable();
        }

        public void Raise<TEvent>(TEvent aEvent) where TEvent : DomainEvent
        {
            subject.OnNext(aEvent);
        }

        #region Disposed

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            subject.Dispose();

            _disposed = true;
        }
        #endregion
    }
}
