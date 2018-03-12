using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using System;
using Common.Domain.Model.Domain;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories
{
    public interface EnvioRepository : AggregateRootRepository<Envio, EnvioId, Guid>
    {
    }
}
