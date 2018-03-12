using System;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories
{
    public interface UnitOfWork : IDisposable
    {
        Task<int> CommitAsync();

        int Commit();

    }
}