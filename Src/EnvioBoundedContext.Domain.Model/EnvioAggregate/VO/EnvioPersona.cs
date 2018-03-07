using System;
using Common.Domain.Model;
using Newtonsoft.Json;

namespace EnvioBoundedContext.Domain.Model.EnvioAggregate.VO
{
    /// <summary>
    /// Entidad Persona
    /// </summary>
    public class EnvioPersona : Common.Domain.Model.Domain.ValueObject<EnvioPersona>
    {
        // 2. Public Properties
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid Id { get; }

        public string Nombre { get; }

        public string Apellido1 { get; }

        public string Apellido2 { get; }


        // 3. Constructor
        [JsonConstructor]
        public EnvioPersona(Guid id, string nombre, string apellido1, string apellido2) : this(nombre, apellido1, apellido2)
        {
            Id = id;
        }

        public EnvioPersona(string nombre, string apellido1, string apellido2)
        {
            Requires.NotNullOrEmpty(nombre, nameof(nombre));
            Requires.NotNullOrEmpty(apellido1, nameof(apellido1));
            Requires.NotNullOrEmpty(apellido2, nameof(apellido2));

            Id = Guid.NewGuid();
            Nombre = nombre;
            Apellido1 = apellido1;
            Apellido2 = apellido2;
        }


        // 4. Public methods
        public string ObtenerNombreCompleto() => $"{Nombre} {Apellido1} {Apellido2}";

        // 5. Private methods

    }
}
