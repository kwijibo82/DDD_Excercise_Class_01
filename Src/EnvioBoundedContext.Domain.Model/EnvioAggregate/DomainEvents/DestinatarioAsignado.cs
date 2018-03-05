﻿using Common.Domain.Model.Bases;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.DomainEvents
{
    public class DestinatarioAsignado : DomainEvent
    {
        public Guid Id { get; }

        public string Nombre { get; }

        public string Apellido1 { get; }

        public string Apellido2 { get; }

        public EnvioId EnvioId { get; }

        public DateTime OccuredOn { get; }


        public DestinatarioAsignado(Guid uId, string nombre, string apellido1, string apellido2, EnvioId envioId)
        {
            Id = uId;
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
            EnvioId = envioId;
            OccuredOn = DateTime.UtcNow;
        }
    }
}
