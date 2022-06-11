using System;
using Compartido.Dto.Distribuidora.General;

namespace Compartido.Dto.Inventario.General
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        public EmpresaDistribuidoraDTO EmpresaDistribuidora { get; set; }
        public string Nombre { get; set; }
        public TipoProductoDTO TipoProducto { get; set; }
        public string Descripcion { get; set; }
        
        public Guid TipoProductoId { get; set; }
        public Guid EmpresaDistribuidoraId { get; set; }
    }
}
