using DomainEventsDispacher.Events;

namespace DomainEventsDispacher
{
    public class EventAggregatorCaller : IEventAggregatorCaller
    {
        private readonly Bases.EventDispacher _dispacher;

        public EventAggregatorCaller(Bases.EventDispacher dispacher)
        {
            _dispacher = dispacher;
        }

        public void Algo()
        {
            _dispacher.Raise(new AvisadoEstas("daniel"));
        }
    }
}