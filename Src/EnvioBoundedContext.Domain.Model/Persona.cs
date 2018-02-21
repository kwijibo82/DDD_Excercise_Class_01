﻿using System;
using System.Collections.Generic;

namespace EnvioBoundedContext.Domain.Model
{
    /// <summary>
    /// Entidad Persona
    /// </summary>
    public class Persona
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido1 { get; private set; }
        public string Apellido2 { get; private set; }

        public Persona() { }

        public static Persona CreaPersona(string nombre, string apellido1, string apellido2)
        {
            if (string.IsNullOrEmpty(nombre)) throw new ArgumentNullException("El parámetro 'nombre' está vacío.");
            if (string.IsNullOrEmpty(apellido1)) throw new ArgumentNullException("El parámetro 'apellido1' está vacío.");
            if (string.IsNullOrEmpty(apellido2)) throw new ArgumentNullException("El parámetro 'apellido2' está vacío.");

            Persona persona = new Persona()
            {
                Id = Guid.NewGuid(),
                Nombre = nombre,
                Apellido1 = apellido1,
                Apellido2 = apellido2
            };

            return persona;
        }

        public string ObtenerNombreCompleto()
        {
            var nombreCompleto = string.Format("{0} {1} {2}", Nombre, Apellido1, Apellido2) ;
            return nombreCompleto;
        }

        public static string ObtenerDireccion()
        {
            return "direccion0";
        }

        public static IList<string> ObtenerDireccionesDestinoFavoritas()
        {
            IList<string> direccionesFavoritas = new List<string>
            {
                "direccion1",
                "direccion2",
                "direccion3"
            };

            return direccionesFavoritas;
        }
    }
}
