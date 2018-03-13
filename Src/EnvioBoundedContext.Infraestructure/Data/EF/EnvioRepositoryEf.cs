using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.Domain.Model;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;

namespace EnvioBoundedContext.Infraestructure.Data.EF
{
    public class EnvioRepositoryEf : EnvioRepository
    {
        private readonly EnvioContext _context;

        internal EnvioRepositoryEf(EnvioContext context)
        {
            this._context = context;
        }

        public async Task<Envio> GetByIdAsync(EnvioId id)
        {
            EnvioSnapShot snapShot = await _context.Envios
                .Include(e => e.Remitente)
                .Include(e => e.DireccionEntrega)
                .Include(e => e.Destinatario)
                .Include(e => e.DireccionRecogida)
                .Include(e => e.Bultos)
                .Where(e => e.EnvioSnapShotId == id.Key)
                .SingleOrDefaultAsync();
            //.Where(b => b.FullName == BuyerIdentityGuid)
            //SingleOrDefaultAsync();
            if (snapShot == null)
                return null;

            return new Envio(snapShot);

        }


        // string tipoVia, string nombreCalle, string numeroPortal, string piso, string puerta, string escalera, string codigoPostal, string localidad, string provincia
        public Task SaveAsync(Envio entity)
        {
            EnvioSnapShot envioSnapShot = entity.GetSnapShot();

            _context.Envios.Add(envioSnapShot);

            return Task.CompletedTask;
        }



        public void ActualizarDestinatarioEnEnvioExistente(Envio envio)
        {
            EnvioSnapShot envioSnapShot = envio.GetSnapShot();
            _context.Envios.Attach(envioSnapShot);
            if (envioSnapShot.Destinatario.EnvioPersonaSnapShotId == Guid.Empty)
            {
                envioSnapShot.Destinatario.EnvioPersonaSnapShotId = Guid.NewGuid();
                envioSnapShot.DestinatarioId = envioSnapShot.Destinatario.EnvioPersonaSnapShotId;
                _context.Personas.Add(envioSnapShot.Destinatario);
            }
            else if (envioSnapShot.Destinatario.EnvioPersonaSnapShotId == envioSnapShot.DestinatarioId)
            {
                _context.Personas.Attach(envioSnapShot.Destinatario);
                _context.Entry(envioSnapShot.Destinatario).State = EntityState.Modified;
            }
            else
            {
                envioSnapShot.DestinatarioId = envioSnapShot.Destinatario.EnvioPersonaSnapShotId;
                _context.Personas.Add(envioSnapShot.Destinatario);
            }




        }


    }


}
