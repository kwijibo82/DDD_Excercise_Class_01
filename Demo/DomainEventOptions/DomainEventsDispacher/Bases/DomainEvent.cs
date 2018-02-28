using System;

namespace DomainEventsDispacher.Bases
{
    public interface DomainEvent
    {
        DateTime OccuredOn { get; }
    }
}