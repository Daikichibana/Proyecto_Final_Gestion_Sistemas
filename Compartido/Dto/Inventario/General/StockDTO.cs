using System;

namespace Compartido.Dto.Inventario.General
{
    public class StockDTO
    {
        public Guid Id { get; set; }
        public ProductoDTO Producto { get; set; }
        public int Cantidad { get; set; }
        public int CantidadPedida { get; set; }
        public int CantidadOrdenada { get; set; }
        public decimal PrecioCompraPromedio { get; set; }
        public decimal PrecioVentaPromedio { get; set; }

        public Guid ProductoId { get; set; }
    }
}