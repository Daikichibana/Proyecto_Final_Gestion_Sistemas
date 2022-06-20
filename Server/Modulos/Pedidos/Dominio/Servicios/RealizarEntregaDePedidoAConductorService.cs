using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarEntregaDePedidoAConductorService : IRealizarEntregaDePedidoAConductorService
    {
        UnidadDeTrabajo _unidad;

        public RealizarEntregaDePedidoAConductorService(BaseDatosContext contexto)
        {
            _unidad = new UnidadDeTrabajo(contexto);
        }

        public void ConfirmarEntregaPedido(Guid IdPedido) {
            var pedido = _unidad.pedidoRepository.ObtenerPorId(IdPedido);
            pedido.EstadoEnvio = "Producto en camino";
            _unidad.pedidoRepository.Actualizar(pedido);
            _unidad.Complete();
        }
    }
}
