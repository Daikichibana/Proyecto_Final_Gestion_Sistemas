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
        IRealizarFacturacionClienteService _facturaService;
        public RealizarEntregaDePedidoAClienteService(IMapper mapper, BaseDatosContext contexto, IRealizarFacturacionClienteService facturaService)
        {
            _mapper = mapper;
            _unidad = new UnidadDeTrabajo(contexto);
            _facturaService = facturaService;
        }

        public void ConfirmarEntregaCliente(Guid IdPedido)
        {
            var pedido = _unidad.pedidoRepository.ObtenerPorId(IdPedido);
            pedido.EstadoEnvio = "Pedido Entregado Al cliente.";
            
            _unidad.pedidoRepository.Actualizar(pedido);
            _unidad.Complete();
        }


    }
}
