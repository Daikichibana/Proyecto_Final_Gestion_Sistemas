using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades
{
    public class UsuariosRoles : Entity
    {
        public Usuario Usuario { get; set; }
        public Rol Rol { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }

        [ForeignKey("Rol")]
        public Guid RolId { get; set; }

        public UsuariosRoles()
        {

        }

        public UsuariosRoles(Usuario usuario, Rol rol)
        {
            Usuario = usuario;
            Rol = rol;
        }
    }
}
