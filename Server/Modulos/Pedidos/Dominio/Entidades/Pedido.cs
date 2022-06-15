using System;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades
{
    public class Pedido : Entity
    {
        public OrdenPedido OrdenPedido { get; set; }
        public AsignacionVechiculoConductor ConductorAsignado { get; set; }
        public string EstadoEnvio { get; set; }
        public string EstadoPago { get; set; }
        
        [ForeignKey("OrdenPedido")]
        public Guid OrdenPedidoId { get; set; }
        
        [ForeignKey("ConductorAsignado")]
        public Guid? ConductorAsignadoId { get; set; }

        public Pedido()
        {

        }

        public Pedido(OrdenPedido ordenPedido, AsignacionVechiculoConductor conductorAsignado, string estadoEnvio, string estadoPago, Guid ordenPedidoId, Guid? conductorAsignadoId)
        {
            OrdenPedido = ordenPedido;
            ConductorAsignado = conductorAsignado;
            EstadoEnvio = estadoEnvio;
            EstadoPago = estadoPago;
            OrdenPedidoId = ordenPedidoId;
            ConductorAsignadoId = conductorAsignadoId;
        }
    }
}