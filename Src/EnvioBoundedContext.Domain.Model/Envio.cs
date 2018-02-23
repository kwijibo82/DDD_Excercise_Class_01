using System;
using System.Collections.Generic;
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

    public enum State
    {
        Creado,
        DireccionRecogidaAsignada,
        DireccionEntregaAsignada,
        DireccionesAsignadas,
        ServicioCalculado,
        BultosAgregados,
        EnvioParaRecoger
    }

    public enum Trigger
    {
        AsignarDireccionRecogida,
        AsignarDireccionEntrega,
    }

    public class Envio
    {
        Stateless.StateMachine<State, Trigger> _stateMachine;
        Guid id;

        public Envio(Guid id)
        {
            Id = id;
            _stateMachine = new Stateless.StateMachine<State, Trigger>(State.Creado);

            _stateMachine.Configure(State.Creado)
                .Permit(Trigger.AsignarDireccionRecogida, State.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, State.DireccionEntregaAsignada);

            _stateMachine.Configure(State.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, State.DireccionesAsignadas);
                

        }

        public State State => _stateMachine.State;
        public Guid Id { get; }
        public Persona Destinatario { get; set; }
        public int Estado { get; set; }
        public Servicio Servicio { get; private set; }

        public void AsignarDireccionRecogida(Direccion nuevaDireccion)
        {
            if (IsInReparto)
            {
                throw new InvalidOperationException();
            }

            bool existPreviousDireccion = DireccionRecogida != null;

            if (DireccionRecogida == nuevaDireccion)
            {
                return;
            }

            DireccionRecogida = nuevaDireccion;
            
            _stateMachine.Fire(Trigger.AsignarDireccionRecogida);

            

            //Notificar
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

        private bool IsInReparto => Estado == 5;

        public Direccion DireccionEntrega { get; private set; }
        public Direccion DireccionRecogida { get; private set; }

        public IEnumerable<Bulto> Bultos { get; private set; }

    }
}