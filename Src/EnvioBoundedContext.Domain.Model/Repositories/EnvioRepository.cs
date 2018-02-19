using System;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model.Repositories
{
    public interface EnvioRepository
    {
        Task<Envio> GetEnvioBy(Guid envioId);
    }
}
