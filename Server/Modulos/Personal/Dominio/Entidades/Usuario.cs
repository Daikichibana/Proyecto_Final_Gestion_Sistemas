using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades
{
    public class Usuario : Entity
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }

        public Usuario()
        {

        }
        public Usuario(string nombreUsuario, string clave)
        {
            NombreUsuario = nombreUsuario;
            Clave = clave;
        }

    }
}
