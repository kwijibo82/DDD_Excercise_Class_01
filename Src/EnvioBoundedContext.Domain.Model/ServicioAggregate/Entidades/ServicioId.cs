using System;
using Common.Domain.Model;
using Common.Domain.Model.Domain;

namespace EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades
{
    public class ServicioId : ValueObject<ServicioId>, Identity<Guid>
    {
        public ServicioId(Guid key)
        {
            Requires.NotDefaulValue(key, nameof(key));

            this.Key = key;
        }
        public Guid Key { get; }
    }
}