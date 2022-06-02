﻿using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using System;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES
{
    public class ResponsableAlmacen : Entity, IPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

        public ResponsableAlmacen(string nombre, string apellido, string ci, DateTime fechaNacimiento, string email, string telefono)
        {
            Nombre = nombre;
            Apellido = apellido;
            Ci = ci;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
        }

        public ResponsableAlmacen()
        {

        }
    }
}
