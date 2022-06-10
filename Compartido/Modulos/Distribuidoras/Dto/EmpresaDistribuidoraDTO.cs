using System;
using Compartido.Modulos.Basico.Dto;

namespace Compartido.Modulos.Distribuidoras.Dto
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
