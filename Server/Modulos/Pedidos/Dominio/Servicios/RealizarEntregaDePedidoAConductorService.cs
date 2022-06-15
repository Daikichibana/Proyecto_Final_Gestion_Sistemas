using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarEntregaDePedidoAConductorService : IRealizarEntregaDePedidoAConductorService
    {
        IPedidoRepository _pedidoRepository;

        public RealizarEntregaDePedidoAConductorService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public void ConfirmarEntregaPedido(Guid IdPedido) {
            var pedido = _pedidoRepository.ObtenerPorId(IdPedido);
            pedido.EstadoEnvio = "Producto entregado a conductor";
            _pedidoRepository.Actualizar(pedido);
        }
    }
}
