using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class AsignarEntregaAConductorService : IAsignarEntregaAConductorService
    {
        IPedidoRepository _pedidoRepository;

        public AsignarEntregaAConductorService(IPedidoRepository pedidoRepository) {
            _pedidoRepository = pedidoRepository;
        }

        public void AsignarEntregaAconductor(Guid IdConductorVehiculo, Guid IdPedido) {
            Pedido pedido = _pedidoRepository.ObtenerPorId(IdPedido);
            pedido.ConductorAsignadoId = IdConductorVehiculo;
            pedido.EstadoEnvio = "Pedido Asignado";
            _pedidoRepository.Actualizar(pedido);
        }
    }
}
