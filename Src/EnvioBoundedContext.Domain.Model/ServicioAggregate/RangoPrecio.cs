namespace EnvioBoundedContext.Domain.Model
{
    public class RangoPrecio
    {
        // TODO: Tanto las entidades como los VO tienen propiedades readonly
        // TODO: Faltan validaciones
        public decimal From { get; set; }
        public decimal Hasta { get; set; }
    }
}
