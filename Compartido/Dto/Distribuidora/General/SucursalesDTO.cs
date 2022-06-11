using System;

namespace Compartido.Dto.Distribuidora.General
{
    public class SucursalesDTO 
    {
        public Guid Id { get; set; }
        public int NroSucursal { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public EmpresaDistribuidoraDTO EmpresaDistribuidora { get; set; }
        
        public Guid EmpresaDistribuidoraId { get; set; }
    }
}
