using System;

namespace Compartido.Dto.Personal.General
{
    public class UsuariosRolesDTO
    {
        public Guid Id { get; set; }
        public UsuarioDTO Usuario { get; set; }
        public RolDTO Rol { get; set; }
        
        public Guid UsuarioId { get; set; }
        public Guid RolId { get; set; }
    }
}
