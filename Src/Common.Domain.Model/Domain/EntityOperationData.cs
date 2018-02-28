using System;
using System.Threading.Tasks;

namespace Common.Domain.Model.Domain
{
    public interface EntityOperationData<TEntity, in TIdentity, TKey>
        where TEntity : Entity<TIdentity, TKey> where TIdentity : Identity<TKey> where TKey : IComparable
    {
        
    }
}