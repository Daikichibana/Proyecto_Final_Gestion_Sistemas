using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades
{
    public class Usuario : Entity
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public Rol Rol { get; set; }

        [ForeignKey("Rol")]
        public Guid RolId { get; set; }

        public Usuario(string nombreUsuario, string clave, Rol rol)
        {
            NombreUsuario = nombreUsuario;
            Clave = clave;
            Rol = rol;
        }

        public Usuario()
        {

        }
    }
}
