using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using System;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories
{
    public interface EnvioRepository
    {
        Task<Envio> GetEnvioBy(Guid envioId);
    }
}
