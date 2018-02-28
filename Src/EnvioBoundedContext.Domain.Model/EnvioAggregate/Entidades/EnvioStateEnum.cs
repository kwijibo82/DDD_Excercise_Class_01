using Common.Domain.Model;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public class EnvioStateEnum : Enumeration
    {
        public static EnvioStateEnum Creado = new EnvioStateEnum("1", "Creado");
        public static EnvioStateEnum DireccionRecogidaAsignada = new EnvioStateEnum("2", "DireccionRecogidaAsignada");
        public static EnvioStateEnum DireccionEntregaAsignada = new EnvioStateEnum("3", "DireccionEntregaAsignada");
        public static EnvioStateEnum DireccionesAsignadas = new EnvioStateEnum("4", "DireccionesAsignadas");
        public static EnvioStateEnum EnvioRecogido = new EnvioStateEnum("7", "EnvioRecogido");

        public EnvioStateEnum(string key, string description) : base(key, description)
        {
        }

        public static bool IsEnvioInProgress(EnvioStateEnum state)
        {
            int.TryParse(state.Id, out int stateId);
            return stateId < 7;
        }
    }
}