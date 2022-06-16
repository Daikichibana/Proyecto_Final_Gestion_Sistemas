using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarPedidoADistribuidoraService : IRealizarPedidoADistribuidoraService
    {
        IOrdenPedidoRepository _ordenRepository;
        IDetalleOrdenPedidoRepository _detalleOrdenPedidoRepository;

        IActualizarStockPorCompraService _actualizarStockPorCompraService;
        public RealizarPedidoADistribuidoraService(IActualizarStockPorCompraService actualizarStockPorCompraService, IDetalleOrdenPedidoRepository detalleOrdenPedidoRepository, IOrdenPedidoRepository ordenRepository) {
            _actualizarStockPorCompraService = actualizarStockPorCompraService;
            _detalleOrdenPedidoRepository = detalleOrdenPedidoRepository;
            _ordenRepository = ordenRepository;
        }

        public void RealizarOrdenPedido(OrdenPedido orden, List<DetalleOrdenPedido> ProductoCarrito) {

            _ordenRepository.Guardar(orden);

            foreach (var producto in ProductoCarrito) {
                var StockProducto = _actualizarStockPorCompraService.ObtenerPorIdStock(producto.Id);
                StockProducto.CantidadOrdenada = producto.CantidadOrdenada;

                _actualizarStockPorCompraService.ActualizarStock(StockProducto);
                _detalleOrdenPedidoRepository.Guardar(producto);
            }
        }

    }
}
