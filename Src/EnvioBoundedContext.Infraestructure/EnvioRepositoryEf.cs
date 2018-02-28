using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;

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
