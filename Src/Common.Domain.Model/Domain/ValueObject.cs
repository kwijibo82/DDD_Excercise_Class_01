using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Common.Domain.Model.Domain
{

    public interface AggregateRootRepository<TAggregateRoot>
        where TAggregateRoot : AggregateRoot
    {

    }

    public interface EntityOperationData<TEntity, in TIdentity, TKey>
        where TEntity : Entity<TIdentity, TKey> where TIdentity : Identity<TKey> where TKey : IComparable
    {
        Task<TEntity> GetByIdAsync(TIdentity id);

        Task SaveAsync(TEntity entity);
    }

    public interface OrderRepository : EntityOperationData<Order, OrderId, string>, AggregateRootRepository<Order>
    {

    }

    public class OrderRepositoryEf : OrderRepository
    {
        public Task<Order> GetByIdAsync(OrderId id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Order entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface AggregateRoot { }

    public interface Identity<out TKey> where TKey : IComparable
    {
        TKey Key { get; }
    }

    public interface Entity<out TIdentity, TKey>
        where TIdentity : Identity<TKey>
        where TKey : IComparable
    {
        TIdentity Id { get; }
    }

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

    public class OrderId : Identity<string>
    {
        public OrderId(string key)
        {
            Key = key;
        }

        public string Key { get; }
    }

    public class Order : EntityBase<OrderId, string>, AggregateRoot
    {
        public Order(OrderId id) : base(id)
        {

        }
    }

    [Serializable]
    public abstract class ValueObject<T> : IEquatable<T> where T : class
    {
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as T;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            IEnumerable<FieldInfo> fields = GetFields();

            const int startValue = 17;
            const int multiplier = 59;

            int hashCode = startValue;

            foreach (FieldInfo field in fields)
            {
                object value = field.GetValue(this);

                if (value != null)
                    hashCode = hashCode * multiplier + value.GetHashCode();
            }

            return hashCode;
        }

        public virtual bool Equals(T other)
        {
            if (other == null)
                return false;

            Type t = GetType();

            FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (FieldInfo field in fields)
            {
                object value1 = null;
                try
                {
                    value1 = field.GetValue(other);
                }
                catch
                {
                    // Swallow this one, value1 is defaulted to null
                }
                object value2 = field.GetValue(this);

                if (value1 == null)
                {
                    if (value2 != null)
                        return false;
                }
                else if (value2 == null)
                {
                    return false;
                }
                else if ((typeof(DateTime).IsAssignableFrom(field.FieldType)) || ((typeof(DateTime?).IsAssignableFrom(field.FieldType))))
                {
                    var dateString1 = ((DateTime)value1).ToLongDateString();
                    var dateString2 = ((DateTime)value2).ToLongDateString();
                    if (!dateString1.Equals(dateString2))
                    {
                        return false;
                    }
                    continue;
                }
                else if (!value1.Equals(value2))
                    return false;
            }

            return true;
        }

        private IEnumerable<FieldInfo> GetFields()
        {
            Type t = GetType();

            var fields = new List<FieldInfo>();

            while (t != typeof(object))
            {
                fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

                t = t.BaseType;
            }

            return fields;
        }

        public static bool operator ==(ValueObject<T> x, ValueObject<T> y)
        {
            return x?.Equals(y) ?? y is null;
        }

        public static bool operator !=(ValueObject<T> x, ValueObject<T> y)
        {
            return !(x == y);
        }
    }
}
