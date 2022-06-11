using System;
using Compartido.Dto.Distribuidora.General;

namespace Compartido.Dto.Inventario.General
{
    public class NotaRecepcionDTO
    {
        public Guid Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public EmpresaProveedorDTO Proveedor { get; set; }
        public EmpresaDistribuidoraDTO Distribuidora { get; set; }
        
        public Guid ProveedorId { get; set; }
        public Guid DistribuidoraId { get; set; }
    }
}
