using System;
using System.Collections.Generic;
using Common.Domain.Model.Domain;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class Envio : AggregateRoot<EnvioId, Guid>
    {
        readonly Stateless.StateMachine<EnvioStateEnum, Trigger> _stateMachine;
        private readonly List<Bulto> _bultos;

        public Envio(Guid id) : base(new EnvioId(id))
        {
            _stateMachine = new Stateless.StateMachine<EnvioStateEnum, Trigger>(EnvioStateEnum.Creado);

            _stateMachine.Configure(EnvioStateEnum.Creado)
                .Permit(Trigger.AsignarDireccionRecogida, EnvioStateEnum.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, EnvioStateEnum.DireccionEntregaAsignada);

            _stateMachine.Configure(EnvioStateEnum.DireccionRecogidaAsignada)
                .Permit(Trigger.AsignarDireccionEntrega, EnvioStateEnum.DireccionesAsignadas);

            _stateMachine.Configure(EnvioStateEnum.DireccionEntregaAsignada)
                .Permit(Trigger.AsignarDireccionRecogida, EnvioStateEnum.DireccionesAsignadas);

            _bultos = new List<Bulto>();
        }

        public ServicioId ServicioId { get; private set; }

        public EnvioStateEnum EnvioState => _stateMachine.State;

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

            //Notificamos
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

            if (_stateMachine.State == EnvioStateEnum.DireccionesAsignadas)
            {
                //Notificar
            }
        }

        private bool IsInProgress => EnvioStateEnum.IsEnvioInProgress(_stateMachine.State);


    }
}