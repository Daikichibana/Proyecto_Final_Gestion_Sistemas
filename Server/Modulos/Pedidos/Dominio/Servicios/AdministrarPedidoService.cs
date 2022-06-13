using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class AdministrarPedidoService : IAdministrarPedidoService
    {
        IPedidoRepository _pedidoRepository;
        IOrdenPedidoRepository _ordenPedidoRepository;
        IDetalleOrdenPedidoRepository _DetalleOrdenPedidoRepository;

        public AdministrarPedidoService(IPedidoRepository pedidoRepository, IDetalleOrdenPedidoRepository DetalleOrdenPedidoRepository, IOrdenPedidoRepository ordenPedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _ordenPedidoRepository = ordenPedidoRepository;
            _DetalleOrdenPedidoRepository = DetalleOrdenPedidoRepository;
        }

        public Pedido Actualizar(Pedido entity)
        {
            return _pedidoRepository.Actualizar(entity);
        }

        public DetalleOrdenPedido ActualizarDetalleOrdenPedido(DetalleOrdenPedido entity)
        {
            return _DetalleOrdenPedidoRepository.Actualizar(entity);
        }

        public OrdenPedido ActualizarOrdenPedido(OrdenPedido entity)
        {
            return _ordenPedidoRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _pedidoRepository.Eliminar(id);
        }

        public void EliminarDetalleOrdenPedido(Guid id)
        {
            _DetalleOrdenPedidoRepository.Eliminar(id);
        }

        public void EliminarOrdenPedido(Guid id)
        {
            _ordenPedidoRepository.Eliminar(id);
        }

        public Pedido Guardar(Pedido entity)
        {
            return _pedidoRepository.Guardar(entity);
        }

        public DetalleOrdenPedido GuardarDetalleOrdenPedido(DetalleOrdenPedido entity)
        {
            return _DetalleOrdenPedidoRepository.Guardar(entity);
        }

        public OrdenPedido GuardarOrdenPedido(OrdenPedido entity)
        {
            return _ordenPedidoRepository.Guardar(entity);
        }

        public Pedido ObtenerPorId(Guid id)
        {
            return _pedidoRepository.ObtenerPorId(id);
        }

        public DetalleOrdenPedido ObtenerPorIdDetalleOrdenPedido(Guid id)
        {
            return _DetalleOrdenPedidoRepository.ObtenerPorId(id);
        }

        public OrdenPedido ObtenerPorIdOrdenPedido(Guid id)
        {
            return _ordenPedidoRepository.ObtenerPorId(id);
        }

        public IList<Pedido> ObtenerTodo()
        {
            return _pedidoRepository.ObtenerTodo(); 
        }

        public IList<DetalleOrdenPedido> ObtenerTodoDetalleOrdenPedido()
        {
            return _DetalleOrdenPedidoRepository.ObtenerTodo();
        }

        public IList<OrdenPedido> ObtenerTodoOrdenPedido()
        {
            return _ordenPedidoRepository.ObtenerTodo();
        }
    }
}
