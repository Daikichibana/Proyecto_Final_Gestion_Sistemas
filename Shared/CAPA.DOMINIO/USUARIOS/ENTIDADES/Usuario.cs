

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES
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
