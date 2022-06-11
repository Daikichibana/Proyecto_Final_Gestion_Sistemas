using System;

namespace Compartido.Dto.Inventario.General
{
    public class ProductoDTO
    {
        // Datos Producto
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        // Datos Tipo Producto
        public TipoProductoDTO TipoProducto { get; set; }

        public Guid TipoProductoId { get; set; }
    }
}
