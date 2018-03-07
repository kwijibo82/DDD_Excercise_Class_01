using System;
using System.Linq;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
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
            Envio envio = EnvioBuilder.GetEnvio(idGuid);
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

    }
}
