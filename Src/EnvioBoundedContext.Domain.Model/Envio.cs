using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.Repositories;

namespace EnvioBoundedContext.Domain.Model
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
    public class Envio
    {
        public string Destinatario { get; set; }
    }
}