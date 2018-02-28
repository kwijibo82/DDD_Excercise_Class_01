using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class EnvioDomainService
    {
        private readonly EnvioRepository _envioRepository;

        public EnvioDomainService(EnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        public async Task<Envio> GetOneBy(Guid envioId)
        {
            Envio envio = await _envioRepository.GetEnvioBy(envioId);
            if (envio == null)
            {
                throw new ApplicationException("Not found");
            }

            return envio;
        }
    }
}