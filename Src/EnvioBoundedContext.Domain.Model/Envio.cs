using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Domain.Model;
using Common.Domain.Model.Domain;
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
        EnvioParaRecoger,
        EnvioRecogido
    }

    public enum Trigger
    {
        AsignarDireccionRecogida,
        AsignarDireccionEntrega,
    }

    public class EnvioId : Identity<Guid>
    {
        public EnvioId(Guid key)
        {
            Requires.NotDefaulValue(key, nameof(key));
            Key = key;
        }

        public Guid Key { get; }
    }

    public class Envio : EntityBase<EnvioId, Guid>
    {
        readonly Stateless.StateMachine<State, Trigger> _stateMachine;
        private List<Bulto> _bultos;

        public Envio(Guid id) : base(new EnvioId(id))
        {
            _stateMachine = new Stateless.StateMachine<State, Trigger>(State.Creado);

            _stateMachine.Configure(State.Creado)
                .Permit(Trigger.AsignarDireccionRecogida, State.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, State.DireccionEntregaAsignada);

            _stateMachine.Configure(State.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, State.DireccionesAsignadas);

            _stateMachine.Configure(State.DireccionEntregaAsignada)
                .Permit(Trigger.AsignarDireccionRecogida, State.DireccionesAsignadas);

            _bultos = new List<Bulto>();
        }

        public State State => _stateMachine.State;

        public Persona Remitente { get; private set; }

        public Persona Destinatario { get; private set; }

        public Direccion DireccionEntrega { get; private set; }

        public Direccion DireccionRecogida { get; private set; }

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
            _stateMachine.Fire(Trigger.AsignarDireccionEntrega);
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
            _stateMachine.Fire(Trigger.AsignarDireccionRecogida);

            if (_stateMachine.State == State.DireccionesAsignadas)
            {
                //Notificar
            }
        }

        private bool IsInReparto => _stateMachine.State == State.EnvioRecogido;

        public IEnumerable<Bulto> Bultos => _bultos;
    }
}