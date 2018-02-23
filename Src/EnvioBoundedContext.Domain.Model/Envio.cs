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
        public Persona Remitente { get; private set; }
        public Persona Destinatario { get; private set; }
        public Direccion DireccionEntrega { get; private set; }
        public Direccion DireccionRecogida { get; private set; }
        public int Estado { get; set; }
        public Servicio Servicio { get; private set; }

        public void AsignarRemitente(Persona nuevoRemitente)
        {
            if (IsInReparto)
            {
                throw new InvalidOperationException();
            }

            if (Remitente == nuevoRemitente)
            {
                return;
            }

            Remitente = nuevoRemitente;

            //Notificamos

        }

        public void AsignarDestinatario(Persona nuevoDestinatario)
        {
            if (IsInReparto)
            {
                throw new InvalidOperationException();
            }

            if (Destinatario == nuevoDestinatario)
            {
                return;
            }

            Destinatario = nuevoDestinatario;

            //Notificamos

        }

        public void AsignarDireccionEntrega(Direccion nuevaDireccion)
        {
            if (IsInReparto)
            {
                throw new InvalidOperationException();
            }

            if (DireccionEntrega == nuevaDireccion)
            {
                return;
            }

            DireccionEntrega = nuevaDireccion;
        }

        public void AsignarDireccionRecogida(Direccion nuevaDireccion)
        {
            if (IsInReparto)
            {
                throw new InvalidOperationException();
            }

            if (DireccionRecogida == nuevaDireccion)
            {
                return;
            }

            DireccionRecogida = nuevaDireccion;
        }


        private bool IsInReparto => Estado == 5;
    }
}