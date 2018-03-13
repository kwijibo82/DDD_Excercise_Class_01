using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain.Model;
using Common.Domain.Model.Domain;
using Common.Domain.Model.EventAggregator;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.DomainEvents;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Domain.Model.ServicioAggregate;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;
using EnvioBoundedContext.Infraestructure.Data.EF;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class Envio : AggregateRoot<EnvioId, Guid>
    {
        readonly Stateless.StateMachine<EnvioState, Trigger> _stateMachine;


        private EnvioSnapShot snapShot;


        private EnvioState myState { get; set; }

        public Envio(EnvioSnapShot snapShot) : this(snapShot.EnvioSnapShotId)
        {
            this.snapShot = snapShot;
        }

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

        }

        public EnvioSnapShot GetSnapShot()
        {
            snapShot.EnvioState = myState.Id;
            return snapShot;
        }

        public void AsignarRemitente(EnvioPersona nuevoRemitente)
        {
            if (!IsInProgress)
            {
                throw new InvalidOperationException();
            }

            if (snapShot.Remitente == null)
            {
                snapShot.Remitente = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.Empty,
                    Nombre = nuevoRemitente.Nombre,
                    Apellido1 = nuevoRemitente.Apellido1,
                    Apellido2 = nuevoRemitente.Apellido2
                };
                return;
            }
            if (snapShot.Remitente.EnvioPersonaSnapShotId == nuevoRemitente.Id)
            {
                snapShot.Remitente.Update(nuevoRemitente);
            }

            //Notificamos
        }

        public void AsignarDestinatario(EnvioPersona nuevoDestinatario)
        {
            if (!IsInProgress)
            {
                throw new InvalidOperationException();
            }


            if (snapShot.Destinatario == null)
            {
                snapShot.Destinatario = new EnvioPersonaSnapShot
                {
                    EnvioPersonaSnapShotId = Guid.Empty,
                    Nombre = nuevoDestinatario.Nombre,
                    Apellido1 = nuevoDestinatario.Apellido1,
                    Apellido2 = nuevoDestinatario.Apellido2
                };
                return;
            }

            if (snapShot.Destinatario.EnvioPersonaSnapShotId == nuevoDestinatario.Id)
            {
                snapShot.Destinatario.Nombre = nuevoDestinatario.Nombre;
                snapShot.Destinatario.Apellido1 = nuevoDestinatario.Apellido1;
                snapShot.Destinatario.Apellido2 = nuevoDestinatario.Apellido2;
                return;
            }

            IEventAggregatorReactive eventAggregator = ContainerFactory.Resolve<IEventAggregatorReactive>();
            eventAggregator.Raise(new DestinatarioDesasignado(snapShot.DestinatarioId.Value, Id));

            snapShot.Destinatario = new EnvioPersonaSnapShot
            {
                EnvioPersonaSnapShotId = nuevoDestinatario.Id,
                Nombre = nuevoDestinatario.Nombre,
                Apellido1 = nuevoDestinatario.Apellido1,
                Apellido2 = nuevoDestinatario.Apellido2
            };


            //eventAggregator.Raise(new DestinatarioAsignado(nuevoDestinatario.Id, nuevoDestinatario.Nombre, nuevoDestinatario.Apellido1, nuevoDestinatario.Apellido2, Id));
        }

        public void AsignarDireccionEntrega(Direccion nuevaDireccion)
        {
            //if (!IsInProgress)
            //{
            //    throw new InvalidOperationException();
            //}

            //if (DireccionEntrega == nuevaDireccion)
            //{
            //    return;
            //}

            //DireccionEntrega = nuevaDireccion;

            //_stateMachine.Fire(Trigger.AsignarDireccionEntrega);
        }

        public void AsignarDireccionRecogida(Direccion nuevaDireccion)
        {
            //if (!IsInProgress)
            //{
            //    throw new InvalidOperationException();
            //}

            //if (DireccionRecogida == nuevaDireccion)
            //{
            //    return;
            //}

            //DireccionRecogida = nuevaDireccion;
            //_stateMachine.Fire(Trigger.AsignarDireccionRecogida);

            //if (_stateMachine.State == EnvioState.DireccionesAsignadas)
            //{
            //    //Notificar
            //}
        }

        private bool IsInProgress => EnvioState.IsEnvioInProgress(_stateMachine.State);


        public void AgregarBultos(Politica politicaServicio, Bulto bulto)
        {
            //if (!IsInProgress)
            //{
            //    return;
            //}

            //Peso pesoTotal = new Peso(UnidadPeso.Gramo, 0d);
            //foreach (var item in _bultos)
            //{
            //    pesoTotal = pesoTotal + item.Peso.CambiarAGramos();
            //}

            //pesoTotal = pesoTotal + bulto.Peso.CambiarAGramos();

            //if (!politicaServicio.EsPesoValido(pesoTotal))
            //{
            //    throw new ArgumentException("Invalid by policy");
            //}

            //_bultos.Add(bulto);
        }

        public void QuitarBulto(Bulto bulto)
        {
            //int position = _bultos.IndexOf(bulto);
            //if (position >= 0)
            //{
            //    _bultos.RemoveAt(position);
            //}
        }
    }
}