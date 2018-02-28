using System;
using System.Threading.Tasks;
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

        public void Save(Envio envio)
        {
            //envio.getSnapShot();
            string id = $"envio.Id.Key";

        }
    }


}
