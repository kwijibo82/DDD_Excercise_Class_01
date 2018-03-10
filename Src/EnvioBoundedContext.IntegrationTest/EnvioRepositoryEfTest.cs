using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Infraestructure.Data.EF;
using Xunit;
using Xunit2.Should;

namespace EnvioBoundedContext.IntegrationTest
{
    public class EnvioRepositoryEfTest
    {
        public EnvioRepositoryEfTest()
        {
            Database.SetInitializer(new EnvioContextInitializer());
        }

        [Fact]
        public async Task LeerEnvioDatosMinimosAsync()
        {
            Guid envioId = new Guid("BD31DDF7-CB6D-4FA1-9014-56F8368CF01F");
            using (var unitOfWork = new EnvioUnitOfWorkDefault())
            {
                Envio envioRead = await unitOfWork.EnvioRepository.GetByIdAsync(new EnvioId(envioId));
                envioRead.ShouldNotBeNull();
                envioRead.Id.Key.ShouldBe(envioId);
                envioRead.ServicioId.ShouldBeNull();

                envioRead.Remitente.ShouldBeNull();
                envioRead.DireccionRecogida.ShouldBeNull();
                envioRead.Destinatario.ShouldBeNull();
                envioRead.DireccionEntrega.ShouldBeNull();
                envioRead.Bultos.Count().ShouldBe(0);
            }
        }

        [Fact]
        public async Task LeerEnvioRecogidaAsync()
        {
            Guid envioId = new Guid("88DE0C3A-7758-4F90-BCCD-E5101D27E322");
            using (var unitOfWork = new EnvioUnitOfWorkDefault())
            {
                Envio envioRead = await unitOfWork.EnvioRepository.GetByIdAsync(new EnvioId(envioId));
                envioRead.ShouldNotBeNull();
                envioRead.Id.Key.ShouldBe(envioId);
                envioRead.Remitente.ShouldNotBeNull();
                envioRead.DireccionRecogida.ShouldNotBeNull();

                envioRead.ServicioId.ShouldBeNull();
                envioRead.Destinatario.ShouldBeNull();
                envioRead.DireccionEntrega.ShouldBeNull();
                envioRead.Bultos.Count().ShouldBe(0);
            }
        }

        [Fact]
        public async Task LeerEnvioAmbasDireccionesAsync()
        {
            Guid envioId = new Guid("50A3A557-1EF4-4762-8A51-A08900055824");
            using (var unitOfWork = new EnvioUnitOfWorkDefault())
            {
                Envio envioRead = await unitOfWork.EnvioRepository.GetByIdAsync(new EnvioId(envioId));
                envioRead.ShouldNotBeNull();
                envioRead.Id.Key.ShouldBe(envioId);
                envioRead.Remitente.ShouldNotBeNull();
                envioRead.DireccionRecogida.ShouldNotBeNull();
                envioRead.Destinatario.ShouldNotBeNull();
                envioRead.DireccionEntrega.ShouldNotBeNull();

                envioRead.ServicioId.ShouldBeNull();
                envioRead.Bultos.Count().ShouldBe(0);
            }
        }

        [Fact]
        public async Task LeerEnvioServicioAsignadoAsync()
        {
            Guid envioId = new Guid("173A1432-1082-4941-9547-CF3F8A946E9A");
            using (var unitOfWork = new EnvioUnitOfWorkDefault())
            {
                Envio envioRead = await unitOfWork.EnvioRepository.GetByIdAsync(new EnvioId(envioId));
                envioRead.ShouldNotBeNull();
                envioRead.Id.Key.ShouldBe(envioId);
                envioRead.Remitente.ShouldNotBeNull();
                envioRead.DireccionRecogida.ShouldNotBeNull();
                envioRead.Destinatario.ShouldNotBeNull();
                envioRead.DireccionEntrega.ShouldNotBeNull();
                envioRead.ServicioId.ShouldNotBeNull();

                envioRead.Bultos.Count().ShouldBe(0);
            }
        }

        [Fact]
        public async Task LeerEnvioListoRecogidaAsync()
        {
            Guid envioId = new Guid("482B3A5F-02D5-4533-AC49-6A8503C5EB39");
            using (var unitOfWork = new EnvioUnitOfWorkDefault())
            {
                Envio envioRead = await unitOfWork.EnvioRepository.GetByIdAsync(new EnvioId(envioId));
                envioRead.ShouldNotBeNull();
                envioRead.Id.Key.ShouldBe(envioId);
                envioRead.Remitente.ShouldNotBeNull();
                envioRead.DireccionRecogida.ShouldNotBeNull();
                envioRead.Destinatario.ShouldNotBeNull();
                envioRead.DireccionEntrega.ShouldNotBeNull();
                envioRead.ServicioId.ShouldNotBeNull();
                envioRead.Bultos.Count().ShouldBe(1);
            }
        }
    }
}