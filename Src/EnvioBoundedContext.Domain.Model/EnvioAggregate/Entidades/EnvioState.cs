using System;
using Common.Domain.Model;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class EnvioState : Enumeration
    {
        public static EnvioState Creado = new EnvioState("1", "Creado");
        public static EnvioState DireccionRecogidaAsignada = new EnvioState("2", "DireccionRecogidaAsignada");
        public static EnvioState DireccionEntregaAsignada = new EnvioState("3", "DireccionEntregaAsignada");
        public static EnvioState DireccionesAsignadas = new EnvioState("4", "DireccionesAsignadas");
        public static EnvioState ServicioAsignado = new EnvioState("5", "DireccionesAsignadas");
        public static EnvioState ListoRecogida = new EnvioState("6", "DireccionesAsignadas");
        public static EnvioState EnvioRecogido = new EnvioState("7", "EnvioRecogido");

        public EnvioState()
        {

        }

        public EnvioState(string key, string description) : base(key, description)
        {
        }

        public static bool IsEnvioInProgress(EnvioState state)
        {
            int.TryParse(state.Id, out int stateId);
            return stateId < 7;
        }

        public static void FromValue<T>(string envioStateKey, out T state)
        {
            throw new NotImplementedException();
        }
    }
}