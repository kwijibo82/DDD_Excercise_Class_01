using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Domain.Model.ServicioAggregate;
using EnvioBoundedContext.Infraestructure.Data;
using Xunit;
using Xunit2.Should;

namespace EnvioBoundedContext.IntegrationTest
{
    public class EnvioRepositoryTest
    {
        [Fact]
        public async Task GuardarEnvioAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid idGuid = Guid.NewGuid();
            Envio envio = EnvioBuilder.BuildEnvio(idGuid);
            await sut.SaveAsync(envio);
            Envio envioRead = await sut.GetByIdAsync(new EnvioId(idGuid));
            // Envio envioRead = await sut.GetByIdAsync(new EnvioId(new Guid("6c16c477-3384-4b7f-87e1-5ae08a91a5fb")));
            // await sut.GetAll();

            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(envio.EnvioState);
            envioRead.ServicioId.ShouldBe(envio.ServicioId);
            envioRead.Destinatario.ShouldBe(envio.Destinatario);
            envioRead.Remitente.ShouldBe(envio.Remitente);
            envioRead.DireccionEntrega.ShouldBe(envio.DireccionEntrega);
            envioRead.DireccionRecogida.ShouldBe(envio.DireccionRecogida);
            envioRead.Bultos.Count().ShouldBe(envio.Bultos.Count());

            for (var index = 0; index < envioRead.Bultos.Count(); index++)
            {
                envioRead.Bultos.ElementAt(index).ShouldBe(envio.Bultos.ElementAt(index));
            }

        }

        [Fact]
        public async Task GuardarEnvioDatosMinimosAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid idGuid = Guid.NewGuid();
            Envio envio = EnvioBuilder.BuildEnvio(idGuid);
            await sut.SaveAsync(envio);
            Envio envioRead = await sut.GetByIdAsync(new EnvioId(idGuid));
            // Envio envioRead = await sut.GetByIdAsync(new EnvioId(new Guid("6c16c477-3384-4b7f-87e1-5ae08a91a5fb")));
            // await sut.GetAll();

            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(EnvioState.Creado);
            envioRead.ServicioId.ShouldBeNull();
            envioRead.Destinatario.ShouldBeNull();
            envioRead.Remitente.ShouldBeNull();
            envioRead.DireccionEntrega.ShouldBeNull();
            envioRead.DireccionRecogida.ShouldBeNull();
            envioRead.Bultos.Count().ShouldBe(0);
        }

        [Fact]
        public async Task GuardarEnvioComoNuevoRemitenteAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid envioId = Guid.NewGuid();
            Guid servicioId = Guid.NewGuid();

            Envio envio = EnvioBuilder.BuildEnvio(envioId, EnvioState.Creado.Id);
            await sut.SaveAsync(envio);
            Envio envioRead = await sut.GetByIdAsync(new EnvioId(envioId));
            // Envio envioRead = await sut.GetByIdAsync(new EnvioId(new Guid("6c16c477-3384-4b7f-87e1-5ae08a91a5fb")));
            // await sut.GetAll();

            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(envio.EnvioState);
            envioRead.ServicioId.ShouldBeNull();
            envioRead.Destinatario.ShouldBeNull();
            envioRead.Remitente.ShouldBeNull();
            envioRead.DireccionEntrega.ShouldBeNull();
            envioRead.DireccionRecogida.ShouldBeNull();
            envioRead.Bultos.Count().ShouldBe(0);
        }

        [Fact]
        public async Task GuardarEnvioDatosRecogidaCompletosAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid envioId = Guid.NewGuid();
            Guid remitenteId = Guid.NewGuid();
            Envio envio = EnvioBuilder.BuildEnvio(envioId, EnvioState.DireccionRecogidaAsignada.Id, remitente: EnvioBuilder.GetDefaultRemitente(remitenteId), direccionRecogida: EnvioBuilder.GetDefaultDireccionRecogida());
            await sut.SaveAsync(envio);

            Envio envioRead = await sut.GetByIdAsync(new EnvioId(envioId));


            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(envio.EnvioState);
            envioRead.Remitente.ShouldBe(envio.Remitente);
            envioRead.Remitente.Id.ShouldBe(remitenteId);
            envioRead.DireccionRecogida.ShouldBe(envio.DireccionRecogida);

            envioRead.Destinatario.ShouldBeNull();
            envioRead.DireccionEntrega.ShouldBeNull();
            envioRead.Bultos.Count().ShouldBe(0);
            envioRead.ServicioId.ShouldBeNull();
        }

        [Fact]
        public async Task GuardarEnvioDatosRecogidaEntregaCompletosAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid envioId = Guid.NewGuid();
            Guid remitenteId = Guid.NewGuid();
            Guid destinatarioId = Guid.NewGuid();
            Envio envio = EnvioBuilder.BuildEnvio(envioId, EnvioState.DireccionesAsignadas.Id,
                remitente: EnvioBuilder.GetDefaultRemitente(remitenteId), direccionRecogida: EnvioBuilder.GetDefaultDireccionRecogida(),
                destinatario: EnvioBuilder.GetDefaultDestinatario(destinatarioId), direccionEntrega: EnvioBuilder.GetDefaultDireccionEntrega());

            await sut.SaveAsync(envio);

            Envio envioRead = await sut.GetByIdAsync(new EnvioId(envioId));


            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(envio.EnvioState);
            envioRead.Remitente.ShouldBe(envio.Remitente);
            envioRead.Remitente.Id.ShouldBe(remitenteId);
            envioRead.DireccionRecogida.ShouldBe(envio.DireccionRecogida);
            envioRead.Destinatario.ShouldBe(envio.Destinatario);
            envioRead.Destinatario.Id.ShouldBe(destinatarioId);
            envioRead.DireccionEntrega.ShouldBe(envio.DireccionEntrega);

            envioRead.Bultos.Count().ShouldBe(0);
            envioRead.ServicioId.ShouldBeNull();
        }

        [Fact]
        public async Task GuardarEnvioConServicioAsignadosAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid envioId = Guid.NewGuid();
            Guid remitenteId = Guid.NewGuid();
            Guid destinatarioId = Guid.NewGuid();
            Guid servicioId = Guid.NewGuid();

            Envio envio = EnvioBuilder.BuildEnvio(envioId, EnvioState.ServicioAsignado.Id,
                remitente: EnvioBuilder.GetDefaultRemitente(remitenteId), direccionRecogida: EnvioBuilder.GetDefaultDireccionRecogida(),
                destinatario: EnvioBuilder.GetDefaultDestinatario(destinatarioId), direccionEntrega: EnvioBuilder.GetDefaultDireccionEntrega(),
                servicioId: servicioId);

            await sut.SaveAsync(envio);

            Envio envioRead = await sut.GetByIdAsync(new EnvioId(envioId));


            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(envio.EnvioState);
            envioRead.Remitente.ShouldBe(envio.Remitente);
            envioRead.Remitente.Id.ShouldBe(remitenteId);
            envioRead.DireccionRecogida.ShouldBe(envio.DireccionRecogida);
            envioRead.Destinatario.ShouldBe(envio.Destinatario);
            envioRead.Destinatario.Id.ShouldBe(destinatarioId);
            envioRead.DireccionEntrega.ShouldBe(envio.DireccionEntrega);
            envioRead.ServicioId.ShouldBe(envio.ServicioId);
            envioRead.ServicioId.Key.ShouldBe(servicioId);

            envioRead.Bultos.Count().ShouldBe(0);
        }

        [Fact]
        public async Task GuardarEnvioListoRecogidaAsync()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid envioId = Guid.NewGuid();
            Guid remitenteId = Guid.NewGuid();
            Guid destinatarioId = Guid.NewGuid();
            Guid servicioId = Guid.NewGuid();
            IList<Bulto> bultos = new List<Bulto>
            {
                EnvioBuilder.GetDefaultBulto(),
                EnvioBuilder.GetDefaultBulto(new Peso(UnidadPeso.Kilo, 5d),new Dimensiones(6d,7d,8d))
            };

            Envio envio = EnvioBuilder.BuildEnvio(envioId, EnvioState.ListoRecogida.Id,
                remitente: EnvioBuilder.GetDefaultRemitente(remitenteId), direccionRecogida: EnvioBuilder.GetDefaultDireccionRecogida(),
                destinatario: EnvioBuilder.GetDefaultDestinatario(destinatarioId), direccionEntrega: EnvioBuilder.GetDefaultDireccionEntrega(),
                servicioId: servicioId, bultos: bultos);

            await sut.SaveAsync(envio);

            Envio envioRead = await sut.GetByIdAsync(new EnvioId(envioId));

            envioRead.Id.ShouldBe(envio.Id);
            envioRead.EnvioState.ShouldBe(envio.EnvioState);
            envioRead.Remitente.ShouldBe(envio.Remitente);
            envioRead.Remitente.Id.ShouldBe(remitenteId);
            envioRead.DireccionRecogida.ShouldBe(envio.DireccionRecogida);
            envioRead.Destinatario.ShouldBe(envio.Destinatario);
            envioRead.Destinatario.Id.ShouldBe(destinatarioId);
            envioRead.DireccionEntrega.ShouldBe(envio.DireccionEntrega);
            envioRead.ServicioId.ShouldBe(envio.ServicioId);
            envioRead.ServicioId.Key.ShouldBe(servicioId);
            envioRead.Bultos.Count().ShouldBe(envio.Bultos.Count());

            for (int position = 0; position < envioRead.Bultos.Count(); position++)
            {
                envioRead.Bultos.ElementAt(position).ShouldBe(envio.Bultos.ElementAt(position));
            }

        }

        [Fact]
        public async Task AgregarYQuitarBultosEnUnEnvioGuardado()
        {
            EnvioRepository sut = new EnvioRepositoryDocDB();
            Guid envioId = Guid.NewGuid();
            // precondition not exist
            Envio envioPrevious = await sut.GetByIdAsync(new EnvioId(envioId));
            envioPrevious.ShouldBeNull();

            Guid remitenteId = Guid.NewGuid();
            Guid destinatarioId = Guid.NewGuid();
            Guid servicioId = Guid.NewGuid();
            IList<Bulto> bultos = new List<Bulto>
            {
                EnvioBuilder.GetDefaultBulto(),
                EnvioBuilder.GetDefaultBulto(new Peso(UnidadPeso.Kilo, 5d),new Dimensiones(6d,7d,8d))
            };

            Envio envioToSave = EnvioBuilder.BuildEnvio(envioId, EnvioState.ListoRecogida.Id,
                remitente: EnvioBuilder.GetDefaultRemitente(remitenteId), direccionRecogida: EnvioBuilder.GetDefaultDireccionRecogida(),
                destinatario: EnvioBuilder.GetDefaultDestinatario(destinatarioId), direccionEntrega: EnvioBuilder.GetDefaultDireccionEntrega(),
                servicioId: servicioId, bultos: bultos);
            await sut.SaveAsync(envioToSave);

            // leer
            Envio envioToModify = await sut.GetByIdAsync(new EnvioId(envioId));
            envioToModify.ShouldNotBeNull();

            // agregar nuevo bulto y borrar uno existente
            Bulto newBulto = new Bulto(new Peso(UnidadPeso.Kilo, 4d), new Dimensiones(3d, 3d, 3d));
            envioToModify.AgregarBultos(Politica.Default, newBulto);
            envioToModify.QuitarBulto(bultos.First());

            await sut.SaveAsync(envioToModify);

            Envio envioValidate = await sut.GetByIdAsync(new EnvioId(envioId));

            envioValidate.Bultos.Count().ShouldBe(2);
            envioValidate.Bultos.Any(c => c.Equals(bultos.ElementAt(1))).ShouldBeTrue();
            envioValidate.Bultos.Any(c => c.Equals(newBulto)).ShouldBeTrue();

            envioValidate.Bultos.Any(c => c.Equals(bultos.ElementAt(0))).ShouldBeFalse();
        }
    }
}
