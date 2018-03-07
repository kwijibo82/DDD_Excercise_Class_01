using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    new Bulto(new Peso(UnidadPeso.Kilo, 5), new Dimensiones(1,2,3)),
                    new Bulto(new Peso(UnidadPeso.Kilo, 6), new Dimensiones(4,5,6))
                }
                );
        }
    }
}
