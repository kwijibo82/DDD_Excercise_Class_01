namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories
{
    public interface EnvioUnitOfWork : UnitOfWork
    {
        EnvioRepository EnvioRepository { get; }
    }
}