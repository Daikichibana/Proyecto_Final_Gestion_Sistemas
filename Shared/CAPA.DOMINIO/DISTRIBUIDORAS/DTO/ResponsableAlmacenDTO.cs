using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO
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
        /*public EmpresaDistribuidora EmpresaDistribuidora { get; set; }
        public Guid EmpresaDitribuidoraId { get; set; }*/
    }
}
