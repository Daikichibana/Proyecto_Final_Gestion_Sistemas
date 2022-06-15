using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Pedido ActualizarPedido(Pedido entity)
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

        public void EliminarPedido(Guid id)
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

        public Pedido GuardarPedido(Pedido entity)
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

        public Pedido ObtenerPorIdPedido(Guid id)
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

        public IList<Pedido> ObtenerTodoPedido()
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
        
        public List<OrdenPedido> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id)
        {
            List<OrdenPedido> listaOrdenPedido = _ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaDistribuidoraId.Equals(Id)).ToList();
            List<OrdenPedido> result = new List<OrdenPedido>();

            foreach (var orden in listaOrdenPedido)
            {
                var pedidoConfirmado = _pedidoRepository.ObtenerTodo().Where(p => p.OrdenPedidoId.Equals(orden.Id)).ToList();

                if (pedidoConfirmado.Count == 0)
                {
                    result.Add(orden);
                }
            }
            
            return result;
        }

        public List<OrdenPedido> ObtenerOrdenesPedidosClientePorId(Guid Id)
        {
            List<OrdenPedido> listaOrdenPedido = _ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaClienteId.Equals(Id)).ToList();
            List<OrdenPedido> result = new List<OrdenPedido>();

            foreach (var orden in listaOrdenPedido)
            {
                var pedidoConfirmado = _pedidoRepository.ObtenerTodo().Where(p => p.OrdenPedidoId.Equals(orden.Id)).ToList();

                if (pedidoConfirmado.Count == 0)
                {
                    result.Add(orden);
                }
            }

            return result;
        }

        public List<Pedido> ObtenerPedidosDistribuidoraPorId(Guid Id)
        {
            List<OrdenPedido> ordenesPedido = _ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaDistribuidoraId.Equals(Id)).ToList();
            List<Pedido> pedidosEmpresa = _pedidoRepository.ObtenerTodo().ToList();
            List<Pedido> resultado = new List<Pedido>();

            foreach (var pedido in pedidosEmpresa)
            {
                if (ordenesPedido.Contains(pedido.OrdenPedido))
                { 
                    resultado.Add(pedido);
                }
            }

            return resultado;
        }

        public List<Pedido> ObtenerPedidosClientePorId(Guid Id)
        {
            List<OrdenPedido> ordenesPedido = _ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaClienteId.Equals(Id)).ToList();
            List<Pedido> pedidosEmpresa = _pedidoRepository.ObtenerTodo().ToList();
            List<Pedido> resultado = new List<Pedido>();

            foreach (var pedido in pedidosEmpresa)
            {
                if (ordenesPedido.Contains(pedido.OrdenPedido))
                {
                    resultado.Add(pedido);
                }
            }

            return resultado;
        }

        public void ConfirmarOrdenPedido(Guid Id, bool aceptado)
        {
            OrdenPedido orden = _ordenPedidoRepository.ObtenerPorId(Id);

            if (orden != null && aceptado)
            {
                Pedido pedido = new Pedido(orden, null, "Entrega No Asignada", "No pagado", orden.Id, null);

                _pedidoRepository.Guardar(pedido);
            }
            else if(orden != null && !aceptado)
            {
                _ordenPedidoRepository.Eliminar(orden.Id);
            }
        }

    }
}
