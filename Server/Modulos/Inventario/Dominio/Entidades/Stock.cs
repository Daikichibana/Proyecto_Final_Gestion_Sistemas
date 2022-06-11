using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades
{
    public class Stock : Entity
    {
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public int CantidadPedida { get; set; }
        public int CantidadOrdenada { get; set; }
        public decimal PrecioCompraPromedio { get; set; }
        public decimal PrecioVentaPromedio { get; set; }
        
        [ForeignKey("Producto")]
        public Guid ProductoId { get; set; }


        public Stock()
        {

        }

        public Stock(Producto producto, int cantidad, int cantidadPedida, int cantidadOrdenada, decimal precioCompraPromedio, decimal precioVentaPromedio, Guid productoId)
        {
            Producto = producto;
            Cantidad = cantidad;
            CantidadPedida = cantidadPedida;
            CantidadOrdenada = cantidadOrdenada;
            PrecioCompraPromedio = precioCompraPromedio;
            PrecioVentaPromedio = precioVentaPromedio;
            ProductoId = productoId;
        }
    }
}