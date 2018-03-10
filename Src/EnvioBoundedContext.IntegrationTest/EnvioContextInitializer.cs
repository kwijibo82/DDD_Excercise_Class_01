using System;
using System.Collections.Generic;
using System.Data.Entity;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Infraestructure.Data.EF;

namespace EnvioBoundedContext.IntegrationTest
{
    public class EnvioContextInitializer : DropCreateDatabaseAlways<EnvioContext>
    {
        protected override void Seed(EnvioContext context)
        {

            EnvioSnapShot envioBasico = new EnvioSnapShot
            {
                EnvioSnapShotId = new Guid("BD31DDF7-CB6D-4FA1-9014-56F8368CF01F"),
                EnvioState = EnvioState.Creado.Id
            };
            EnvioSnapShot envioRemitente = new EnvioSnapShot
            {
                EnvioSnapShotId = new Guid("88DE0C3A-7758-4F90-BCCD-E5101D27E322"),
                EnvioState = EnvioState.DireccionRecogidaAsignada.Id,
                Remitente = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreDestinario",
                    Apellido1 = "apellido1Destinario",
                    Apellido2 = "apellido2Destinario"
                },
                DireccionRecogida = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaE",
                    NombreCalle = "nombreCalleE",
                    NumeroPortal = "numeroPortalE",
                    Piso = "pisoE",
                    Puerta = "puertaE",
                    Escalera = "escaleraE",
                    CodigoPostal = "codigoPostalE",
                    Localidad = "localidadE",
                    Provincia = "provinciaE"
                }

            };

            EnvioSnapShot envioDireccionesAsignadas = new EnvioSnapShot
            {
                EnvioSnapShotId = new Guid("50A3A557-1EF4-4762-8A51-A08900055824"),
                EnvioState = EnvioState.DireccionesAsignadas.Id,
                Remitente = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreRemitente",
                    Apellido1 = "apellido1Remitente",
                    Apellido2 = "apellido2Remitente"
                },
                DireccionRecogida = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaR",
                    NombreCalle = "nombreCalleR",
                    NumeroPortal = "numeroPortalR",
                    Piso = "pisoR",
                    Puerta = "puertaR",
                    Escalera = "escaleraR",
                    CodigoPostal = "codigoPostalR",
                    Localidad = "localidadR",
                    Provincia = "provinciaR"
                },
                Destinatario = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreDestinario",
                    Apellido1 = "apellido1Destinario",
                    Apellido2 = "apellido2Destinario"
                },
                DireccionEntrega = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaE",
                    NombreCalle = "nombreCalleE",
                    NumeroPortal = "numeroPortalE",
                    Piso = "pisoE",
                    Puerta = "puertaE",
                    Escalera = "escaleraE",
                    CodigoPostal = "codigoPostalE",
                    Localidad = "localidadE",
                    Provincia = "provinciaE"
                }
            };

            EnvioSnapShot envioServicioAsignado = new EnvioSnapShot
            {
                EnvioSnapShotId = new Guid("173A1432-1082-4941-9547-CF3F8A946E9A"),
                EnvioState = EnvioState.ServicioAsignado.Id,
                ServicioId = Guid.NewGuid(),
                Remitente = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreRemitente",
                    Apellido1 = "apellido1Remitente",
                    Apellido2 = "apellido2Remitente"
                },
                DireccionRecogida = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaR",
                    NombreCalle = "nombreCalleR",
                    NumeroPortal = "numeroPortalR",
                    Piso = "pisoR",
                    Puerta = "puertaR",
                    Escalera = "escaleraR",
                    CodigoPostal = "codigoPostalR",
                    Localidad = "localidadR",
                    Provincia = "provinciaR"
                },
                Destinatario = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreDestinario",
                    Apellido1 = "apellido1Destinario",
                    Apellido2 = "apellido2Destinario"
                },
                DireccionEntrega = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaE",
                    NombreCalle = "nombreCalleE",
                    NumeroPortal = "numeroPortalE",
                    Piso = "pisoE",
                    Puerta = "puertaE",
                    Escalera = "escaleraE",
                    CodigoPostal = "codigoPostalE",
                    Localidad = "localidadE",
                    Provincia = "provinciaE"
                }
            };

            EnvioSnapShot envioListoRecogida = new EnvioSnapShot
            {
                EnvioSnapShotId = new Guid("482B3A5F-02D5-4533-AC49-6A8503C5EB39"),
                EnvioState = EnvioState.ListoRecogida.Id,
                ServicioId = Guid.NewGuid(),
                Remitente = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreRemitente",
                    Apellido1 = "apellido1Remitente",
                    Apellido2 = "apellido2Remitente"
                },
                DireccionRecogida = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaR",
                    NombreCalle = "nombreCalleR",
                    NumeroPortal = "numeroPortalR",
                    Piso = "pisoR",
                    Puerta = "puertaR",
                    Escalera = "escaleraR",
                    CodigoPostal = "codigoPostalR",
                    Localidad = "localidadR",
                    Provincia = "provinciaR"
                },
                Destinatario = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.NewGuid(),
                    Nombre = "nombreDestinario",
                    Apellido1 = "apellido1Destinario",
                    Apellido2 = "apellido2Destinario"
                },
                DireccionEntrega = new DireccionSnapShot
                {
                    DireccionSnapShotId = Guid.NewGuid(),
                    TipoVia = "tipoViaE",
                    NombreCalle = "nombreCalleE",
                    NumeroPortal = "numeroPortalE",
                    Piso = "pisoE",
                    Puerta = "puertaE",
                    Escalera = "escaleraE",
                    CodigoPostal = "codigoPostalE",
                    Localidad = "localidadE",
                    Provincia = "provinciaE"
                },
                Bultos = new List<BultoSnapShot>
                {
                    new BultoSnapShot
                    {
                        BultoSnapShotId = Guid.NewGuid(),
                        EnvioSnapShotId = new Guid("482B3A5F-02D5-4533-AC49-6A8503C5EB39"),
                        Alto = 2d,
                        Ancho = 2d,
                        Largo = 2d,
                        UnidadPeso = UnidadPeso.Kilo.Id,
                        Peso = 1d
                    }
                }
            };

            IList<EnvioSnapShot> envios = new List<EnvioSnapShot>
            {
                envioBasico,
                envioRemitente,
                envioDireccionesAsignadas,
                envioServicioAsignado,
                envioListoRecogida
            };
            context.Envios.AddRange(envios);

            base.Seed(context);
        }
    }
}