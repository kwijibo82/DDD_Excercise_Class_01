using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;

namespace EnvioBoundedContext.Infraestructure
{
    public class EnvioRepositoryEf : EnvioRepository
    {
        public Task<Envio> GetByIdAsync(EnvioId id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Envio entity)
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }
    }


}
