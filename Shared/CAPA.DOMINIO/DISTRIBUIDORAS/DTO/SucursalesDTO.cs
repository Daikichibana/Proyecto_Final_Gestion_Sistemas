using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO
{
    public class SucursalesDTO
    {
        public Guid id { get; set; }
        public int NroSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        /*public EmpresaDistribuidora EmpresaDistribuidora { get; set; }
        public Guid EmpresaDitribuidoraId { get; set; }*/
    }
}
