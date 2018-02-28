namespace DomainEventsDispacher.Bases
{
    public interface EventDispacher
    {
        void Raise<TEvent>(TEvent aEvent) where TEvent : DomainEvent;
    }
}