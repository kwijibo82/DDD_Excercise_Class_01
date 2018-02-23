using System;
using Common.Domain.Model;

namespace EnvioBoundedContext.Domain.Model
{
    /// <summary>
    /// Entidad Persona
    /// </summary>
    public class Persona : Common.Domain.Model.Domain.ValueObject<Persona>
    {
        // 1. Internal variables
        private Guid _id { get; set; }
        private string _nombre;
        private string _apellido1;
        private string _apellido2;

        // 2. Public Properties
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid Id => _id;

        public string Nombre => _nombre;

        public string Apellido1 => _apellido1;

        public string Apellido2 => _apellido2;


        // 3. Constructor
        public Persona(string nombre, string apellido1, string apellido2)
        {
            Requires.NotNullOrEmpty(nombre, nameof(nombre));
            Requires.NotNullOrEmpty(apellido1, nameof(apellido1));
            Requires.NotNullOrEmpty(apellido2, nameof(apellido2));

            _id = Guid.NewGuid();
            _nombre = nombre;
            _apellido1 = apellido1;
            _apellido2 = apellido2;
        }


        // 4. Public methods
        public string ObtenerNombreCompleto() => $"{Nombre} {Apellido1} {Apellido2}";

        // 5. Private methods



    }
}
