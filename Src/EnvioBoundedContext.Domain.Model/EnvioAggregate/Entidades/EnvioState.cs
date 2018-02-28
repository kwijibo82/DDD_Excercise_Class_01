namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades
{
    public enum EnvioState
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
}