using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using System;
using Xunit;
using Xunit2.Should;

namespace EnvioBoundedContext.Domain.Model.UnitTest
{
    public class EnvioTest
    {
        [Fact]
        public void AsignarNuevoDestinatario()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Persona nuevaPersona = new Persona("Nombre", "Apellido1", "Apellido2");

            sut.AsignarDestinatario(nuevaPersona);

            sut.Destinatario.ShouldBe(nuevaPersona);
        }

        [Fact]
        public void AsignarDestinatarioPorSegundaVez()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Persona nuevaPersona = new Persona("Nombre", "Apellido1", "Apellido2");
            Persona nuevaPersona2 = new Persona("Nombre", "Apellido1", "Apellido2");

            sut.AsignarDestinatario(nuevaPersona);
            sut.AsignarDestinatario(nuevaPersona2);

            ReferenceEquals(sut.Destinatario, nuevaPersona2).ShouldBe(true);

        }

        [Fact]
        public void AsignarNuevoRemitente()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Persona nuevaPersona = new Persona("Nombre", "Apellido1", "Apellido2");

            sut.AsignarRemitente(nuevaPersona);

            sut.Remitente.ShouldBe(nuevaPersona);
        }

        [Fact]
        public void AsignarRemitentePorSegundaVez()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Persona nuevaPersona = new Persona("Nombre", "Apellido1", "Apellido2");
            Persona nuevaPersona2 = new Persona("Nombre", "Apellido1", "Apellido2");

            sut.AsignarRemitente(nuevaPersona);
            sut.AsignarRemitente(nuevaPersona2);

            ReferenceEquals(sut.Remitente, nuevaPersona2).ShouldBe(true);

        }

        [Fact]
        public void AsignarDireccionRecogida()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Direccion nuevaDireccion = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");

            sut.AsignarDireccionRecogida(nuevaDireccion);

            sut.DireccionRecogida.ShouldBe(nuevaDireccion);
        }

        [Fact]
        public void AsignarDireccionRecogidaPorSegundaVez()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Direccion nuevaDireccion = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");
            Direccion nuevaDireccion2 = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");

            sut.AsignarDireccionRecogida(nuevaDireccion);
            sut.AsignarDireccionRecogida(nuevaDireccion2);

            ReferenceEquals(sut.DireccionRecogida, nuevaDireccion).ShouldBe(true);
        }

        [Fact]
        public void AsignarDireccionEntrega()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Direccion nuevaDireccion = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");

            sut.AsignarDireccionEntrega(nuevaDireccion);

            sut.DireccionEntrega.ShouldBe(nuevaDireccion);
        }

        [Fact]
        public void AsignarDireccionEntregaPorSegundaVez()
        {
            Envio sut = new Envio(Guid.NewGuid());
            Direccion nuevaDireccion = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");
            Direccion nuevaDireccion2 = new Direccion("tipo via", "via", "numero", "piso", "puerta", "escalera", "CP", "localidad", "provi");

            sut.AsignarDireccionEntrega(nuevaDireccion);
            sut.AsignarDireccionEntrega(nuevaDireccion2);

            ReferenceEquals(sut.DireccionEntrega, nuevaDireccion).ShouldBe(true);
        }
    }
}