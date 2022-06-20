using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades
{
    public class DetalleNotaRecepcion : Entity
    {
        public NotaRecepcion NotaRecepcion { get; set; }
        public Stock Stock { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("NotaRecepcion")]
        public Guid NotaRecepcionId { get; set; }

        [ForeignKey("Stock")]
        public Guid StockId { get; set; }

        public DetalleNotaRecepcion()
        {

        }

        public DetalleNotaRecepcion(NotaRecepcion notaRecepcion, Stock stock, int cantidad, Guid notaId, Guid stockId)
        {
            NotaRecepcion = notaRecepcion;
            Stock = stock;
            Cantidad = cantidad;
            NotaRecepcionId = notaId;
            StockId = stockId;
        }
    }
}
