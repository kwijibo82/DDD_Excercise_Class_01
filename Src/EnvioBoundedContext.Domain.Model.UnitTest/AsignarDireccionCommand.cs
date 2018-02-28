using System;

namespace EnvioBoundedContext.Domain.Model.UnitTest
{
    public class AsignarDireccionCommand
    {
        public AsignarDireccionCommand(Guid envioId, string calle, string numero)
        {

        }
        public Guid EnvioId { get; private set; }
        public string Calle { get; private set; }
        public string Numero { get; private set; }
    }
}