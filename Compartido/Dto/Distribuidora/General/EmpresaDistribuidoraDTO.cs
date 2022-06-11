using System;
using Compartido.Dto.Personal.General;

namespace Compartido.Dto.Distribuidora.General
{
    public class EmpresaDistribuidoraDTO
    {
        public Guid Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public RubroDTO Rubro { get; set; }
        public NITDTO NIT { get; set; }
        public ResponsableEmpresaDTO Responsable { get; set; }
        public Guid ResponsableId { get; set; }
        public Guid RubroId { get; set; }
        public Guid NITid { get; set; }




    }
}
