using System;
using System.Collections.Generic;
using Common.Domain.Model;
using Common.Domain.Model.Domain;
using Common.Domain.Model.EventAggregator;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.DomainEvents;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class Envio : AggregateRoot<EnvioId, Guid>
    {
        readonly Stateless.StateMachine<EnvioState, Trigger> _stateMachine;
        private readonly List<Bulto> _bultos;
 


        private EnvioState myState { get; set; }

        public Envio(Guid id) : base(new EnvioId(id))
        {

            _stateMachine = new Stateless.StateMachine<EnvioState, Trigger>(() => myState,
    s => myState = s);

            _stateMachine.Configure(EnvioState.Creado)
                .Permit(Trigger.AsignarDireccionRecogida, EnvioState.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, EnvioState.DireccionEntregaAsignada);

            _stateMachine.Configure(EnvioState.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, EnvioState.DireccionesAsignadas);

            _stateMachine.Configure(EnvioState.DireccionEntregaAsignada)
                .Permit(Trigger.AsignarDireccionRecogida, EnvioState.DireccionesAsignadas);

            myState = EnvioState.Creado;

            _bultos = new List<Bulto>();

            
        }

        public ServicioId ServicioId { get; private set; }

        public EnvioState EnvioState => myState;

        public EnvioPersona Remitente { get; private set; }

        public EnvioPersona Destinatario { get; private set; }

        public Direccion DireccionEntrega { get; private set; }

        public Direccion DireccionRecogida { get; private set; }

        public IEnumerable<Bulto> Bultos => _bultos;

        public void AsignarRemitente(EnvioPersona nuevoRemitente)
        {
            if (!IsInProgress)
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

        public void AsignarDestinatario(EnvioPersona nuevoDestinatario)
        {
            if (!IsInProgress)
            {
                throw new InvalidOperationException();
            }

            if (Destinatario == nuevoDestinatario)
            {
                return;
            }

            Destinatario = nuevoDestinatario;

            IEventAggregatorReactive eventAggregator = ContainerFactory.Resolve<IEventAggregatorReactive>();
            eventAggregator.Raise<DestinatarioAsignado>(new DestinatarioAsignado(nuevoDestinatario.Id, nuevoDestinatario.Nombre, nuevoDestinatario.Apellido1, nuevoDestinatario.Apellido2, this.Id));
        }

        public void AsignarDireccionEntrega(Direccion nuevaDireccion)
        {
            if (!IsInProgress)
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
            if (!IsInProgress)
            {
                throw new InvalidOperationException();
            }

            if (DireccionRecogida == nuevaDireccion)
            {
                return;
            }

            DireccionRecogida = nuevaDireccion;
            _stateMachine.Fire(Trigger.AsignarDireccionRecogida);

            if (_stateMachine.State == EnvioState.DireccionesAsignadas)
            {
                //Notificar
            }
        }

        private bool IsInProgress => EnvioState.IsEnvioInProgress(_stateMachine.State);


    }
}