using CAPAS.CAPA.DOMINIO.BASICO.DTO;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using System;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO
{
    public class EmpresaDistribuidoraDTO
    {
        public Guid Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public Rubro Rubro { get; set; }
        public NIT NIT { get; set; }
        public ResponsableEmpresa Responsable { get; set; }
        public Guid ResponsableId { get; set; }
        public Guid RubroId { get; set; }
        public Guid NITid { get; set; }




    }
}
