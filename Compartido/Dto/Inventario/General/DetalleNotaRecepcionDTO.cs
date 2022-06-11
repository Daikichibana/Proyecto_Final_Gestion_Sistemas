using System;

namespace Compartido.Dto.Inventario.General
{
    public class DetalleNotaRecepcionDTO
    {
        public Guid Id { get; set; }
        public NotaRecepcionDTO NotaRecepcion { get; set; }
        public StockDTO Stock { get; set; }
        public int Cantidad { get; set; }
        
        public Guid NotaRecepcionId { get; set; }
        public Guid StockId { get; set; }
    }
}
