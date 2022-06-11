using System;
using Compartido.Dto.Distribuidora.General;

namespace Compartido.Dto.Pedidos.General
{
    public class PedidoDTO
    {
        public Guid Id { get; set; }
        public OrdenPedidoDTO OrdenPedido { get; set; }
        public AsignacionVechiculoConductorDTO ConductorAsignado { get; set; }
        public string EstadoEnvio { get; set; }
        public string EstadoPago { get; set; }
        
        public Guid OrdenPedidoId { get; set; }
        public Guid ConductorAsignadoId { get; set; }
    }
}