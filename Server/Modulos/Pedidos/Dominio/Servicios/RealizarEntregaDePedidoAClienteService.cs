using AutoMapper;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarEntregaDePedidoAClienteService : IRealizarEntregaDePedidoAClienteService
    {

        UnidadDeTrabajo _unidad;
        IMapper _mapper;
        public RealizarEntregaDePedidoAClienteService(IMapper mapper, BaseDatosContext contexto)
        {
            _mapper = mapper;
            _unidad = new UnidadDeTrabajo(contexto);
        }

        public void ConfirmarEntregaCliente(Guid IdPedido)
        {
            var pedido = _unidad.pedidoRepository.ObtenerPorId(IdPedido);
            pedido.EstadoEnvio = "Entrega Finalizada";
            
            _unidad.pedidoRepository.Actualizar(pedido);
            _unidad.Complete();
        }


    }
}
