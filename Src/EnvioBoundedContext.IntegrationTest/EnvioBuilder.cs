﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Domain.Model;
using EnvioBoundedContext.Domain.Model;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.Entidades;
using EnvioBoundedContext.Domain.Model.EnvioAggregate.VO;
using EnvioBoundedContext.Domain.Model.ServicioAggregate.Entidades;

namespace EnvioBoundedContext.IntegrationTest
{
    public static class EnvioBuilder
    {
        //public static Envio GetEnvio(Guid id, string stateKey = null, ServicioId servicioId = null,
        //    EnvioPersona remitente = null, EnvioPersona destinatario = null, Direccion direccionEntrega = null,
        //    Direccion direccionRecogida = null, IEnumerable<Bulto> bultos = null)
        //{
        //    return new Envio(id, stateKey, servicioId ?? new ServicioId(Guid.NewGuid()),
        //        remitente ?? new EnvioPersona("nombreRemitente", "apellido1Remitente", "apellido2Remitente"),
        //        destinatario ?? new EnvioPersona("nombreDestinario", "apellido1Destinario", "apellido2Destinario"),
        //        direccionEntrega ?? new Direccion("tipoViaE", "nombreCalleE", "numeroPortalE", "pisoE", "puertaE",
        //            "escaleraE", "codigoPostalE", "localidadE", "provinciaE"),
        //        direccionRecogida ?? new Direccion("tipoViaR", "nombreCalleR", "numeroPortalR", "pisoR", "puertaR",
        //            "escaleraR", "codigoPostalR", "localidadR", "provinciaR"),
        //        bultos ?? new List<Bulto>
        //        {
        //            new Bulto(new Peso(UnidadPeso.Kilo, 5d), new Dimensiones(1d, 2d, 3d)),
        //            new Bulto(new Peso(UnidadPeso.Kilo, 6d), new Dimensiones(4d, 5d, 6d))
        //        }
        //    );
        //}

        public static Envio BuildEnvio(Guid id, string stateKey = null, Guid? servicioId = null,
            EnvioPersona remitente = null, EnvioPersona destinatario = null, Direccion direccionEntrega = null,
            Direccion direccionRecogida = null, IEnumerable<Bulto> bultos = null)
        {
            return new Envio(id, stateKey, servicioId, remitente, destinatario, direccionEntrega, direccionRecogida,
                bultos);
        }

        public static EnvioPersona GetDefaultRemitente(Guid id, string nombre = "nombreRemitente",
            string apellido1 = "apellido1Remitente", string apellido2 = "apellido2Remitente")
        {
            return new EnvioPersona(id, nombre, apellido1, apellido2);
        }

        public static EnvioPersona GetDefaultDestinatario(Guid id, string nombre = "nombreDestinario",
            string apellido1 = "apellido1Destinario", string apellido2 = "apellido2Destinario")
        {
            return new EnvioPersona(id, nombre, apellido1, apellido2);
        }

        public static Direccion GetDefaultDireccionEntrega(string tipoVia = "tipoViaE", string nombreCalle = "nombreCalleE", string numeroPortal = "numeroPortalE",
            string piso = "pisoE", string puerta = "puertaE", string escalera = "escaleraE", string codigoPostal = "codigoPostalE", string localidad = "localidadE", string provincia = "provinciaE")
        {
            return new Direccion(tipoVia, nombreCalle, numeroPortal, piso, puerta, escalera, codigoPostal, localidad, provincia);
        }

        public static Direccion GetDefaultDireccionRecogida(string tipoVia = "tipoViaR", string nombreCalle = "nombreCalleR", string numeroPortal = "numeroPortalR",
            string piso = "pisoR", string puerta = "puertaR", string escalera = "escaleraR", string codigoPostal = "codigoPostalR", string localidad = "localidadR", string provincia = "provinciaR")
        {
            return new Direccion(tipoVia, nombreCalle, numeroPortal, piso, puerta, escalera, codigoPostal, localidad, provincia);
        }

        public static Bulto GetDefaultBulto(Peso peso = null, Dimensiones dimensiones = null)
        {
            peso = peso ?? new Peso(UnidadPeso.Kilo, 5d);
            dimensiones = dimensiones ?? new Dimensiones(1d, 2d, 3d);

            return new Bulto(peso, dimensiones);
        }

    }
}
