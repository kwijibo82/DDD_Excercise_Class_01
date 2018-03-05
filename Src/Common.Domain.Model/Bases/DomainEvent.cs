using System;

namespace Common.Domain.Model.Bases
{
    public interface DomainEvent
    {
        DateTime OccuredOn { get; }

    }
}