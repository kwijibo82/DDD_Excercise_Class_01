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
            EnvioSnapShot envioSnapShot = CrearEnvioSnapShot(entity);

            _context.Envios.Add(envioSnapShot);

            return Task.CompletedTask;
        }

        private static EnvioSnapShot CrearEnvioSnapShot(Envio entity)
        {
            return new EnvioSnapShot
            {
                EnvioSnapShotId = entity.Id.Key,
                EnvioState = entity.EnvioState.Id,
                ServicioId = entity.ServicioId?.Key,
                Remitente = entity.Remitente == null ? null : new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = entity.Remitente.Id,
                    Nombre = entity.Remitente.Nombre,
                    Apellido1 = entity.Remitente.Apellido1,
                    Apellido2 = entity.Remitente.Apellido2
                },
                Destinatario = entity.Destinatario == null ? null : new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = entity.Destinatario.Id,
                    Nombre = entity.Destinatario.Nombre,
                    Apellido1 = entity.Destinatario.Apellido1,
                    Apellido2 = entity.Destinatario.Apellido2
                },
                DireccionEntrega = entity.DireccionEntrega == null ? null : new DireccionSnapShot
                {
                    TipoVia = entity.DireccionEntrega.TipoVia
                                ,
                    NombreCalle = entity.DireccionEntrega.NombreCalle
                                ,
                    NumeroPortal = entity.DireccionEntrega.NumeroPortal
                                ,
                    Piso = entity.DireccionEntrega.Piso
                                ,
                    Puerta = entity.DireccionEntrega.Puerta
                                ,
                    Escalera = entity.DireccionEntrega.Escalera
                                ,
                    CodigoPostal = entity.DireccionEntrega.CodigoPostal
                                ,
                    Localidad = entity.DireccionEntrega.Localidad
                                ,
                    Provincia = entity.DireccionEntrega.Provincia
                },
                DireccionRecogida = entity.DireccionRecogida == null ? null : new DireccionSnapShot
                {
                    TipoVia = entity.DireccionRecogida.TipoVia
                                ,
                    NombreCalle = entity.DireccionRecogida.NombreCalle
                                ,
                    NumeroPortal = entity.DireccionRecogida.NumeroPortal
                                ,
                    Piso = entity.DireccionRecogida.Piso
                                ,
                    Puerta = entity.DireccionRecogida.Puerta
                                ,
                    Escalera = entity.DireccionRecogida.Escalera
                                ,
                    CodigoPostal = entity.DireccionRecogida.CodigoPostal
                                ,
                    Localidad = entity.DireccionRecogida.Localidad
                                ,
                    Provincia = entity.DireccionRecogida.Provincia
                },
                Bultos = entity.Bultos?.Select(b =>
                                new BultoSnapShot
                                {
                                    BultoSnapShotId = Guid.NewGuid(),
                                    UnidadPeso = b.Peso.Unidad.ToString(),
                                    Peso = b.Peso.Valor.Value,
                                    Alto = b.Dimensiones.Alto.Value,
                                    Ancho = b.Dimensiones.Ancho.Value,
                                    Largo = b.Dimensiones.Largo.Value
                                }).ToList()
            };
        }

        public void ActualizarDestinatarioEnEnvioexistente(Envio envio)
        {
            EnvioSnapShot envioSnapShot = CrearEnvioSnapShot(envio);
            envioSnapShot.DestinatarioId = envioSnapShot.Destinatario.EnvioPersonaSnapShotId;
            
            _context.Entry(envioSnapShot).State = EntityState.Modified;
            _context.Entry(envioSnapShot.Destinatario).State = EntityState.Modified;
            _context.Envios.Attach(envioSnapShot);
        }


    }


}
