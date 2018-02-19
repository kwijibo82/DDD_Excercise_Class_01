using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.Repositories;

namespace EnvioBoundedContext.Infraestructure
{
    public class EnvioRepositoryEf : EnvioRepository
    {
        public Task<Envio> GetEnvioBy(Guid envioId)
        {
            throw new NotImplementedException();
        }
    }
}
