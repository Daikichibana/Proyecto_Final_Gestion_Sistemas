using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IRealizarPedidoADistribuidoraService
    {
        void RealizarOrdenPedido(OrdenPedido orden, List<DetalleOrdenPedido> ProductoCarrito);
    }
}
