using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.CLIENTES.DTO
{
    public class EmpresaClienteDTO
    {
        public Guid Id { get; set; }
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public Rubro Rubro { get; set; }
        public NIT NIT { get; set; }
        public ResponsableEmpresa Responsable { get; set; }
      
        public Guid RubroId { get; set; }

        public Guid NITId { get; set; }

        public Guid ResponsableId { get; set; }
    }
}
