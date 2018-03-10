namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories
{
    public interface EnvioUnitOfWorkFactory
    {
        EnvioUnitOfWork Create();
    }
}