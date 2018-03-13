using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class EnvioUnitOfWorkDefault : UnitOfWorkBase<EnvioContext>, EnvioUnitOfWork
    {
        public EnvioRepository EnvioRepository => new EnvioRepositoryEf(Context);
        public void DeleteDestinatarioEnEnvio(Guid envioId, Guid destinatarioId)
        {
            EnvioSnapShot envio = Context.Envios.SingleOrDefault(e => e.EnvioSnapShotId == envioId);

            Context.Personas.Remove(envio.Destinatario);
        }

        //public async Task UpsertDestinatarioEnEnvio(Guid envioId, Guid destinatarioId, string nombre, string apellido1, string apellido2, bool isNew)
        //{
        //    EnvioSnapShot envio = await Context.Envios.SingleOrDefaultAsync(e => e.EnvioSnapShotId == envioId);
        //    if (isNew)
        //    {
        //        envio.DestinatarioId = destinatarioId;
        //        envio.Destinatario = new EnvioPersonaSnapShot
        //        {
        //            Apellido1 = apellido1,
        //            Apellido2 = apellido2,
        //            Nombre = nombre,
        //            EnvioPersonaSnapShotId = destinatarioId
        //        };
        //    }
        //    else
        //    {
        //        envio.Destinatario.Apellido1 = apellido1;
        //        envio.Destinatario.Apellido2 = apellido2;
        //        envio.Destinatario.Nombre = nombre;

        //    }
        //    throw new NotImplementedException();
        //}
    }
}