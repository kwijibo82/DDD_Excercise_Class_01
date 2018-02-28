using System;

namespace Common.Domain.Model.Domain
{
    public abstract class AggregateRoot<TIdentity, TKey> : EntityBase<TIdentity, TKey>
        where TIdentity : Identity<TKey>
        where TKey : IComparable
    {
        protected AggregateRoot(TIdentity identity) : base(identity)
        {
        }
    }
}