using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IRealizarEntregaDePedidoAClienteService
    {
        void ConfirmarEntregaCliente (Guid IdPedido);
    }
}
