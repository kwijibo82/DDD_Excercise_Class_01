using System;
using System.Data.Entity;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public abstract class UnitOfWorkBase<TContext> : UnitOfWork where TContext : DbContext, new()
    {
        protected TContext Context;

        bool _disposed = false;

        protected UnitOfWorkBase()
        {
            Context = new TContext();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWorkBase()
        {
            Dispose(false);
        }

        private void Dispose(bool isDisposing)
        {
            if (_disposed)
            {
                return;
            }
            if (isDisposing)
            {
                Context?.Dispose();
            }

            _disposed = true;

        }

        /// <inheritdoc/>
        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public int Commit()
        {
            return Context.SaveChanges();
        }
    }
}
