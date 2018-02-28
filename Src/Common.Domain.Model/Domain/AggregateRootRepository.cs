using System;
using System.Threading.Tasks;

namespace Common.Domain.Model.Domain
{
    public interface AggregateRootRepository<TAggregateRoot, in TIdentity, TKey>
        where TAggregateRoot : AggregateRoot<TIdentity, TKey>
        where TIdentity : Identity<TKey>
        where TKey : IComparable
    {
        Task<TAggregateRoot> GetByIdAsync(TIdentity id);

        Task SaveAsync(TAggregateRoot entity);
    }
}