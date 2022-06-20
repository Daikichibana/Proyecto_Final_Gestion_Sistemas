using AutoMapper;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class AdministrarPedidoService : IAdministrarPedidoService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        BaseDatosContext _contexto;
        public AdministrarPedidoService(IMapper mapper, BaseDatosContext contexto)
        {
            _mapper = mapper;
            _contexto = contexto;
            _unidad = new UnidadDeTrabajo(_contexto);
        }

        public void EliminarPedido(Guid id)
        {
            _unidad.pedidoRepository.Eliminar(id);
            _unidad.Complete();
        }
        public void EliminarOrdenPedido(Guid id)
        {
            _unidad.ordenPedidoRepository.Eliminar(id);
            _unidad.Complete();
        }

        public PedidoDTO ObtenerPorIdPedido(Guid id)
        {
            return _mapper.Map<PedidoDTO>(_unidad.pedidoRepository.ObtenerPorId(id));
        }

        public OrdenPedidoDTO ObtenerPorIdOrdenPedido(Guid id)
        {
            return _mapper.Map<OrdenPedidoDTO>(_unidad.ordenPedidoRepository.ObtenerPorId(id));
        }

        public List<OrdenPedidoDTO> ObtenerOrdenesPedidosDistribuidoraPorId(Guid Id)
        {
            var listaOrdenPedido = _unidad.ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaDistribuidoraId.Equals(Id));

            foreach (var orden in listaOrdenPedido)
            {
                orden.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(orden.EmpresaClienteId);
                orden.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(orden.EmpresaCliente.NITId);
                orden.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(orden.EmpresaCliente.ResponsableId);
                orden.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(orden.EmpresaCliente.RubroId);
                orden.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(orden.EmpresaCliente.Responsable.UsuarioId);

                orden.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(orden.EmpresaDistribuidoraId);
                orden.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(orden.EmpresaDistribuidora.NITId);
                orden.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(orden.EmpresaDistribuidora.ResponsableId);
                orden.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(orden.EmpresaDistribuidora.RubroId);
                orden.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(orden.EmpresaDistribuidora.Responsable.UsuarioId);
            }

            return _mapper.Map<List<OrdenPedidoDTO>>(listaOrdenPedido);
        }

        public List<OrdenPedidoDTO> ObtenerOrdenesPedidosClientePorId(Guid Id)
        {
            List<OrdenPedido> listaOrdenPedido = _unidad.ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaClienteId.Equals(Id)).ToList();

            foreach (var orden in listaOrdenPedido)
            {
                orden.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(orden.EmpresaClienteId);
                orden.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(orden.EmpresaCliente.NITId);
                orden.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(orden.EmpresaCliente.ResponsableId);
                orden.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(orden.EmpresaCliente.RubroId);
                orden.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(orden.EmpresaCliente.Responsable.UsuarioId);

                orden.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(orden.EmpresaDistribuidoraId);
                orden.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(orden.EmpresaDistribuidora.NITId);
                orden.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(orden.EmpresaDistribuidora.ResponsableId);
                orden.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(orden.EmpresaDistribuidora.RubroId);
                orden.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(orden.EmpresaDistribuidora.Responsable.UsuarioId);

            }

            return _mapper.Map<List<OrdenPedidoDTO>>(listaOrdenPedido);
        }

        public List<PedidoDTO> ObtenerPedidosDistribuidoraPorId(Guid Id)
        {
            List<OrdenPedido> ordenesPedido = _unidad.ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaDistribuidoraId.Equals(Id)).ToList();
            List<Pedido> resultado = new List<Pedido>();

            foreach (var orden in ordenesPedido)
            {
                var pedido = _unidad.pedidoRepository.ObtenerTodo().Where(p => p.OrdenPedidoId.Equals(orden.Id)).FirstOrDefault();
                if (pedido != null)
                {
                    pedido.OrdenPedido = _unidad.ordenPedidoRepository.ObtenerPorId(pedido.OrdenPedidoId);
                    pedido.OrdenPedido.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaClienteId);
                    pedido.OrdenPedido.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.NITId);
                    pedido.OrdenPedido.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.ResponsableId);
                    pedido.OrdenPedido.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.RubroId);
                    pedido.OrdenPedido.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.Responsable.UsuarioId);
                    pedido.OrdenPedido.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidoraId);
                    pedido.OrdenPedido.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.NITId);
                    pedido.OrdenPedido.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.ResponsableId);
                    pedido.OrdenPedido.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.RubroId);
                    pedido.OrdenPedido.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.Responsable.UsuarioId);

                    if (pedido.ConductorAsignadoId != null)
                    {
                        pedido.ConductorAsignado = _unidad.asignacionVechiculoConductorRepository.ObtenerPorId(pedido.ConductorAsignadoId);
                        pedido.ConductorAsignado.Conductor = _unidad.conductorRepository.ObtenerPorId(pedido.ConductorAsignado.ConductorId);
                        pedido.ConductorAsignado.Vechiculo = _unidad.vechiculoRepository.ObtenerPorId(pedido.ConductorAsignado.VechiculoId);
                        pedido.ConductorAsignado.Conductor.Usuario = _unidad.usuarioRepository.ObtenerPorId(pedido.ConductorAsignado.Conductor.UsuarioId);
                    }

                    resultado.Add(pedido);
                }
            }

            return _mapper.Map<List<PedidoDTO>>(resultado);
        }

        public List<PedidoDTO> ObtenerPedidosClientePorId(Guid Id)
        {
            List<OrdenPedido> ordenesPedido = _unidad.ordenPedidoRepository.ObtenerTodo().Where(p => p.EmpresaClienteId.Equals(Id)).ToList();
            List<Pedido> resultado = new List<Pedido>();

            foreach (var orden in ordenesPedido)
            {
                var pedido = _unidad.pedidoRepository.ObtenerTodo().Where(p => p.OrdenPedidoId.Equals(orden.Id)).FirstOrDefault();

                if (pedido != null)
                {
                    pedido.OrdenPedido = _unidad.ordenPedidoRepository.ObtenerPorId(pedido.OrdenPedidoId);
                    pedido.OrdenPedido.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaClienteId);
                    pedido.OrdenPedido.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.NITId);
                    pedido.OrdenPedido.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.ResponsableId);
                    pedido.OrdenPedido.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.RubroId);
                    pedido.OrdenPedido.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaCliente.Responsable.UsuarioId);
                    pedido.OrdenPedido.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidoraId);
                    pedido.OrdenPedido.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.NITId);
                    pedido.OrdenPedido.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.ResponsableId);
                    pedido.OrdenPedido.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.RubroId);
                    pedido.OrdenPedido.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(pedido.OrdenPedido.EmpresaDistribuidora.Responsable.UsuarioId);

                    if (pedido.ConductorAsignadoId != null)
                    {
                        pedido.ConductorAsignado = _unidad.asignacionVechiculoConductorRepository.ObtenerPorId(pedido.ConductorAsignadoId);
                        pedido.ConductorAsignado.Conductor = _unidad.conductorRepository.ObtenerPorId(pedido.ConductorAsignado.ConductorId);
                        pedido.ConductorAsignado.Vechiculo = _unidad.vechiculoRepository.ObtenerPorId(pedido.ConductorAsignado.VechiculoId);
                        pedido.ConductorAsignado.Conductor.Usuario = _unidad.usuarioRepository.ObtenerPorId(pedido.ConductorAsignado.Conductor.UsuarioId);
                    }
                    resultado.Add(pedido);
                }
            }

            return _mapper.Map<List<PedidoDTO>>(resultado);
        }

        public void ConfirmarOrdenPedido(ConfirmarPedidoDTO confirmarPedidoDTO)
        {
            Guid Id = confirmarPedidoDTO.Id;
            bool aceptado = confirmarPedidoDTO.Aceptado;

            OrdenPedido orden = _unidad.ordenPedidoRepository.ObtenerPorId(Id);
            List<DetalleOrdenPedido> listaDetalle = _unidad.detalleOrdenPedidoRepository.ObtenerTodo().Where(p => p.OrdenPedidoId.Equals(orden.Id)).ToList();
            
            if (orden != null && aceptado)
            {
                orden.PedidoConfirmado = true;
                Pedido pedido = new Pedido(null, null, "Entrega No Asignada", "No pagado", orden.Id, null);

                foreach (var detalle in listaDetalle)
                {
                    var stock = _unidad.stockRepository.ObtenerPorId(detalle.StockId);
                    stock.Cantidad -= detalle.CantidadOrdenada;
                    _unidad.stockRepository.Actualizar(stock);
                }

                _unidad.pedidoRepository.Guardar(pedido);
                orden.PedidoConfirmado = true;
                _unidad.ordenPedidoRepository.Actualizar(orden);
            }
            else if (orden != null && !aceptado)
            {
                foreach (var detalle in listaDetalle)
                {
                    var stock = _unidad.stockRepository.ObtenerPorId(detalle.StockId);
                    stock.Cantidad += detalle.CantidadOrdenada;
                    _unidad.stockRepository.Actualizar(stock);
                    _unidad.detalleOrdenPedidoRepository.Eliminar(detalle.Id);
                }

                _unidad.ordenPedidoRepository.Eliminar(orden.Id);
            }

            _unidad.Complete();
        }

        public List<DetalleOrdenPedidoDTO> ObtenerDetalleOrdenPedidoPorIdOrden(Guid Id)
        {
            var response = _unidad.detalleOrdenPedidoRepository.ObtenerTodo().Where(p => p.OrdenPedidoId.Equals(Id)).ToList();

            foreach (var item in response)
            {
                item.Stock = _unidad.stockRepository.ObtenerPorId(item.StockId);
                item.Stock.Producto = _unidad.productoRepository.ObtenerPorId(item.Stock.ProductoId);
                item.OrdenPedido = _unidad.ordenPedidoRepository.ObtenerPorId(item.OrdenPedidoId);
                item.Stock.Producto.TipoProducto = _unidad.tipoProductoRepository.ObtenerPorId(item.Stock.Producto.TipoProductoId);
            }

            return _mapper.Map<List<DetalleOrdenPedidoDTO>>(response);
        }

    }
}
