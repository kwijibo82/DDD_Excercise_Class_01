using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories
{
    public interface EnvioUnitOfWork : UnitOfWork
    {
        EnvioRepository EnvioRepository { get; }
        void DeleteDestinatarioEnEnvio(Guid envioId, Guid destinatarioId);
    }
}