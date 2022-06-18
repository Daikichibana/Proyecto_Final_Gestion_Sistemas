using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IAdministrarPedidoService
    {
        void EliminarPedido(Guid id);
        PedidoDTO ObtenerPorIdPedido(Guid id);
        List<PedidoDTO> ObtenerPedidosDistribuidoraPorId(Guid Id);
        List<PedidoDTO> ObtenerPedidosClientePorId(Guid Id);
        void EliminarOrdenPedido(Guid id);
        OrdenPedidoDTO ObtenerPorIdOrdenPedido(Guid id);
        List<OrdenPedidoDTO> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id);
        List<OrdenPedidoDTO> ObtenerOrdenesPedidosClientePorId(Guid Id);
        void ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmarPedidoDTO);

    }
}
