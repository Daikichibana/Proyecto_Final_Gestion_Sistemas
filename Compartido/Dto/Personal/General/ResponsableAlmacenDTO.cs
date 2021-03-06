using System;
using Compartido.Dto.Distribuidora.General;

namespace Compartido.Dto.Personal.General
{
    public class ResponsableAlmacenDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public EmpresaDistribuidoraDTO Distribuidora { get; set; }
        public UsuarioDTO Usuario { get; set; }
        
        public Guid DistribuidoraId { get; set; }
        public Guid UsuarioId { get; set; }
        
    }
}
