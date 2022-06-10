using System;

namespace Compartido.Modulos.Usuarios.Dto
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public RolDTO Rol { get; set; }
        public Guid RolId { get; set; }
    }
}
