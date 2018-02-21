using System;
using System.Threading.Tasks;
using EnvioBoundedContext.Domain.Model.Repositories;

namespace EnvioBoundedContext.Domain.Model
{
    public class EnvioDomainService
    {
        private readonly EnvioRepository _envioRepository;

        public EnvioDomainService(EnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        public async Task<Envio> GetOneBy(Guid envioId)
        {
            Envio envio = await _envioRepository.GetEnvioBy(envioId);
            if (envio == null)
            {
                throw new ApplicationException("Not found");
            }
            return envio;
        }
    }
    public class Envio
    {
        Guid id;
        public Envio(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
        public string Destinatario { get; set; }
        public int Estado { get; set; }
        public Servicio Servicio { get; private set; }
        public void AsignarDireccionRecogida(Direccion nuevaDireccion)
        {
            if (IsInReparto)
            {
                throw new InvalidOperationException();
            }

            bool exisPreviousDireccion = DireccionEntrega != null;

            if (DireccionEntrega == nuevaDireccion)
            {
                return;
            }

            DireccionEntrega = nuevaDireccion;
            if (exisPreviousDireccion)
            {
                Servicio = null;
            }
            
            //Notificar
        }

        private bool IsInReparto => Estado == 5;

        public Direccion DireccionEntrega { get; private set; }
    }
}