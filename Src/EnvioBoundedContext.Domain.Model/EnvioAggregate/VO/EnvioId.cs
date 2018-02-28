using System;
using Common.Domain.Model;
using Common.Domain.Model.Domain;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.VO
{
    public class EnvioId : ValueObject<EnvioId>, Identity<Guid>
    {
        public EnvioId(Guid key)
        {
            Requires.NotDefaulValue(key, nameof(key));
            Key = key;
        }

        public Guid Key { get; }
    }
}