using System;

namespace Compartido.Modulos.Distribuidoras.Dto
{
    public class ConductorDTO
    {
        public Guid id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public EmpresaDistribuidoraDTO EmpresaDistribuidora { get; set; }
        public Guid EmpresaDitribuidoraId { get; set; }
    }
}
