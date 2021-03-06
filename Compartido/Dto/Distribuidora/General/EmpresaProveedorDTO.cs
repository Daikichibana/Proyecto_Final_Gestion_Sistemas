using System;
using Compartido.Dto.Personal.General;

namespace Compartido.Dto.Distribuidora.General
{
    public class EmpresaProveedorDTO
    {
        public Guid Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public EmpresaDistribuidoraDTO EmpresaDistribuidora { get; set; }
        public RubroDTO Rubro { get; set; }
        public NITDTO NIT { get; set; }
        public ResponsableEmpresaDTO Responsable { get; set; }
        
        public Guid EmpresaDistribuidoraId { get; set; }
        public Guid RubroId { get; set; }
        public Guid NITId { get; set; }
        public Guid ResponsableId { get; set; }
    }
}
