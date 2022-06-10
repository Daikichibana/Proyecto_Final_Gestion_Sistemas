using System;

namespace Compartido.Modulos.Distribuidoras.Dto
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
