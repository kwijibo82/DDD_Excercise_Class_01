using System;
using System.Collections.Generic;

namespace Common.Domain.Model.Domain
{
    public abstract class EntityBase<TIdentity, TKey> : Entity<TIdentity, TKey>
        where TIdentity : Identity<TKey>
        where TKey : IComparable
    {
        protected EntityBase(TIdentity identity)
        {
            Id = identity;
        }

        public TIdentity Id { get; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Entity<TIdentity, TKey>)obj);
        }

        protected bool Equals(Entity<TIdentity, TKey> other)
        {
            return EqualityComparer<TIdentity>.Default.Equals(Id, other.Id);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TIdentity>.Default.GetHashCode(Id);
        }

        public static bool operator ==(EntityBase<TIdentity, TKey> left, EntityBase<TIdentity, TKey> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityBase<TIdentity, TKey> left, EntityBase<TIdentity, TKey> right)
        {
            return !Equals(left, right);
        }
    }
}