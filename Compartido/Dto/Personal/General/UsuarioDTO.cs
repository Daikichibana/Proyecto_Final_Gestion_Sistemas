using System;

namespace Compartido.Dto.Personal.General
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
    }
}
