namespace DomainEventsDispacher.Bases
{
    public interface DomainEventHandler<in TEvent> where TEvent : DomainEvent
    {
        void Handle(TEvent aEvent);
    }
}