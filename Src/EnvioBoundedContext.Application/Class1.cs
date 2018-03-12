using Common.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Repositories;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Application
{
    public interface Command
    {

    }

    public interface CommandProcessor<TCommand>
    {
        Task Process(TCommand command);
    }

    public class AsignarRemitente : Command
    {
        public AsignarRemitente(Guid envioId,string nombre, string apellido1, string apellido2)
        {
            this.EnvioId = envioId;
            this.Nombre = nombre;
            this.Apellido1 = apellido1;
            this.Apellido2 = apellido2;

        }
        public Guid EnvioId { get; }

        public string Nombre { get; }

        public string Apellido1 { get; }

        public string Apellido2 { get; }
    }

    public class AsignarRemitenteProcessor : CommandProcessor<AsignarRemitente>
    {
        public async Task Process(AsignarRemitente command)
        {
            EnvioRepository envioRepository = ContainerFactory.Resolve<EnvioRepository>();
            
            Envio envio = await envioRepository.GetEnvioBy(new EnvioId(command.EnvioId));
            envio.AsignarRemitente(new EnvioPersona(command.Nombre, command.Apellido1, command.Apellido2));
            envioRepository.Save(envio);


        }
    }

    public class EnvioApplicationService
    {
    }
}
