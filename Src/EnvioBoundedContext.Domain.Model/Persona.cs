using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnvioBoundedContext.Domain.Model
{
    /// <summary>
    /// Entidad Persona
    /// </summary>
    public class Persona : IEquatable<Guid>
    {
        // 1. Internal variables
        private Guid _id;
        private string _nombre;
        private string _apellido1;
        private string _apellido2;
        
        // 2. Public Properties
        // Tanto las entidades como los VO tienen propiedades readonly
        public Guid Id
        {
            get
            {
                return _id;
            }
            private set
            {
                _id = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            private set
            {
                _nombre = value;
            }
        }
        
        public string Apellido1
        {
            get
            {
                return _apellido1;
            }
            private set
            {
                _apellido1 = value;
            }
        }

        public string Apellido2
        {
            get
            {
                return _apellido2;
            }
            private set
            {
                _apellido2 = value;
            }
        }


        // 3. Constructor
        public Persona(string nombre, string apellido1, string apellido2)
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
        public string ObtenerNombreCompleto()
        {
            var nombreCompleto = string.Format("{0} {1} {2}", Nombre, Apellido1, Apellido2) ;
            return nombreCompleto;
        }

        public bool Equals(Guid otroId)
        {
            return ((IEquatable<Guid>)Id).Equals(otroId);
        }
        

        // 5. Private methods



    }
}
