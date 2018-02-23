using System;
using Xunit;
using Xunit2.Should;

namespace EnvioBoundedContext.Domain.Model.UnitTest
{
    public class EnvioTest
    {

        [Fact]
        public void AsignarDireccionRecogida()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Direccion nuevaDireccion = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");

            sut.AsignarDireccionRecogida(nuevaDireccion);

            sut.DireccionRecogida.ShouldBe(nuevaDireccion);

            sut.State.ShouldBe(State.DireccionRecogidaAsignada);
        }

        [Fact]
        public void AsignarDireccionRecogidaPorSegundaVez()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Direccion nuevaDireccion = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");
            Direccion nuevaDireccion2 = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");

            sut.AsignarDireccionRecogida(nuevaDireccion);
            sut.AsignarDireccionRecogida(nuevaDireccion2);
            ReferenceEquals(sut.DireccionEntrega, nuevaDireccion).ShouldBe(true);
        }
    }
}