using System;

namespace Common.Domain.Model.Domain
{
    public interface Entity<out TIdentity, TKey>
        where TIdentity : Identity<TKey>
        where TKey : IComparable
    {
        TIdentity Id { get; }
    }
}