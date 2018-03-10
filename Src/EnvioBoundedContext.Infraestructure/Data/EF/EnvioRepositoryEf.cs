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

            return new Envio(snapShot.EnvioSnapShotId, snapShot.EnvioState, snapShot.ServicioId,
                snapShot.Remitente == null ? null : new EnvioPersona(snapShot.Remitente.EnvioPersonaSnapShotId, snapShot.Remitente.Nombre,
                    snapShot.Remitente.Apellido1, snapShot.Remitente.Apellido2),
                snapShot.Destinatario == null ? null : new EnvioPersona(snapShot.Destinatario.EnvioPersonaSnapShotId, snapShot.Destinatario.Nombre,
                    snapShot.Destinatario.Apellido1, snapShot.Destinatario.Apellido2),
                snapShot.DireccionEntrega == null ? null : new Direccion(snapShot.DireccionEntrega.TipoVia
                    , snapShot.DireccionEntrega.NombreCalle
                    , snapShot.DireccionEntrega.NumeroPortal
                    , snapShot.DireccionEntrega.Piso
                    , snapShot.DireccionEntrega.Puerta
                    , snapShot.DireccionEntrega.Escalera
                    , snapShot.DireccionEntrega.CodigoPostal
                    , snapShot.DireccionEntrega.Localidad
                    , snapShot.DireccionEntrega.Provincia),
                snapShot.DireccionRecogida == null ? null : new Direccion(snapShot.DireccionRecogida.TipoVia
                    , snapShot.DireccionRecogida.NombreCalle
                    , snapShot.DireccionRecogida.NumeroPortal
                    , snapShot.DireccionRecogida.Piso
                    , snapShot.DireccionRecogida.Puerta
                    , snapShot.DireccionRecogida.Escalera
                    , snapShot.DireccionRecogida.CodigoPostal
                    , snapShot.DireccionRecogida.Localidad
                    , snapShot.DireccionRecogida.Provincia),
                snapShot.Bultos?.Select(b =>
                    new Bulto(new Peso(Enumeration.FromValue<UnidadPeso>(b.UnidadPeso), b.Peso),
                        new Dimensiones(b.Alto, b.Ancho, b.Largo))).ToList() ?? Enumerable.Empty<Bulto>()
            );
        }


        // string tipoVia, string nombreCalle, string numeroPortal, string piso, string puerta, string escalera, string codigoPostal, string localidad, string provincia
        public Task SaveAsync(Envio entity)
        {
            return Task.CompletedTask;
        }


    }


}
