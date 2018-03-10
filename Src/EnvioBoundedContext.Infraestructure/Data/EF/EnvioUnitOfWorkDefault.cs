using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class EnvioUnitOfWorkDefault : UnitOfWorkBase<EnvioContext>, EnvioUnitOfWork
    {
        public EnvioRepository EnvioRepository => new EnvioRepositoryEf(Context);
    }
}