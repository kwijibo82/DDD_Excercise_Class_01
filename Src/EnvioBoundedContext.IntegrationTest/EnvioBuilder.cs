using System;
using System.Collections.Generic;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Infraestructure.Data.EF;

namespace EnvioBoundedContext.IntegrationTest
{
    public static class EnvioBuilder
    {
        public static Envio BuildEnvio(Guid id, string stateKey = null, Guid? servicioId = null,
            EnvioPersonaSnapShot remitente = null, EnvioPersonaSnapShot destinatario = null, DireccionSnapShot direccionEntrega = null,
            DireccionSnapShot direccionRecogida = null, IEnumerable<BultoSnapShot> bultos = null)
        {
            return new Envio(new EnvioSnapShot
            {
                EnvioSnapShotId = id,
                ServicioId = servicioId,
                Destinatario = destinatario,
                DestinatarioId = destinatario?.EnvioPersonaSnapShotId,
                Remitente = remitente,
                RemitenteId = remitente?.EnvioPersonaSnapShotId,
                DireccionRecogida = direccionRecogida,
                DireccionRecogidaId = direccionRecogida?.DireccionSnapShotId,
                DireccionEntrega = direccionEntrega,
                DireccionEntregaId = direccionEntrega?.DireccionSnapShotId,
                Bultos = bultos == null ? new List<BultoSnapShot>() : new List<BultoSnapShot>(bultos)
            });
        }

        public static EnvioPersona GetDefaultRemitente(Guid id, string nombre = "nombreRemitente",
            string apellido1 = "apellido1Remitente", string apellido2 = "apellido2Remitente")
        {
            return new EnvioPersona(id, nombre, apellido1, apellido2);
        }

        public static EnvioPersona GetDefaultDestinatario(Guid id, string nombre = "nombreDestinario",
            string apellido1 = "apellido1Destinario", string apellido2 = "apellido2Destinario")
        {
            return new EnvioPersona(id, nombre, apellido1, apellido2);
        }

        public static Direccion GetDefaultDireccionEntrega(string tipoVia = "tipoViaE", string nombreCalle = "nombreCalleE", string numeroPortal = "numeroPortalE",
            string piso = "pisoE", string puerta = "puertaE", string escalera = "escaleraE", string codigoPostal = "codigoPostalE", string localidad = "localidadE", string provincia = "provinciaE")
        {
            return new Direccion(tipoVia, nombreCalle, numeroPortal, piso, puerta, escalera, codigoPostal, localidad, provincia);
        }

        public static Direccion GetDefaultDireccionRecogida(string tipoVia = "tipoViaR", string nombreCalle = "nombreCalleR", string numeroPortal = "numeroPortalR",
            string piso = "pisoR", string puerta = "puertaR", string escalera = "escaleraR", string codigoPostal = "codigoPostalR", string localidad = "localidadR", string provincia = "provinciaR")
        {
            return new Direccion(tipoVia, nombreCalle, numeroPortal, piso, puerta, escalera, codigoPostal, localidad, provincia);
        }

        public static Bulto GetDefaultBulto(Peso peso = null, Dimensiones dimensiones = null)
        {
            peso = peso ?? new Peso(UnidadPeso.Kilo, 5d);
            dimensiones = dimensiones ?? new Dimensiones(1d, 2d, 3d);

            return new Bulto(peso, dimensiones);
        }

    }
}
