using System;

namespace Compartido.Dto.Personal.General
{
    public class ResponsableEmpresaDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public UsuarioDTO Usuario { get; set; }
        
        public Guid UsuarioId { get; set; }
    }
}
