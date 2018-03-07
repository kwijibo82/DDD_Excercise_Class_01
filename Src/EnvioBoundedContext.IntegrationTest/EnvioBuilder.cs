using System;
using System.Collections.Generic;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;

namespace EnvioBoundedContext.IntegrationTest
{
    public static class EnvioBuilder
    {
        public static Envio GetEnvio(Guid id, EnvioState state = null, ServicioId servicioId = null, EnvioPersona remitente = null, EnvioPersona destinatario = null, Direccion direccionEntrega = null, Direccion direccionRecogida = null, IEnumerable<Bulto> bultos = null)
        {
            return new Envio(id, state ?? EnvioState.Creado, servicioId ?? new ServicioId(Guid.NewGuid()),
                remitente ?? new EnvioPersona("nombreRemitente", "apellido1Remitente", "apellido2Remitente"),
                destinatario ?? new EnvioPersona("nombreDestinario", "apellido1Destinario", "apellido2Destinario"),
                direccionEntrega ?? new Direccion("tipoViaE", "nombreCalleE", "numeroPortalE", "pisoE", "puertaE", "escaleraE", "codigoPostalE", "localidadE", "provinciaE"),
                direccionRecogida ?? new Direccion("tipoViaR", "nombreCalleR", "numeroPortalR", "pisoR", "puertaR", "escaleraR", "codigoPostalR", "localidadR", "provinciaR"),
                bultos ?? new List<Bulto>
                {
                    new Bulto(new Peso(UnidadPeso.Kilo, 5d), new Dimensiones(1d,2d,3d)),
                    new Bulto(new Peso(UnidadPeso.Kilo, 6d), new Dimensiones(4d,5d,6d))
                }
                );
        }
    }
}
