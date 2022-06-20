using AutoMapper;
using Compartido.Dto.Pedidos.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarFacturacionClienteService : IRealizarFacturacionClienteService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public RealizarFacturacionClienteService(IMapper mapper, BaseDatosContext contexto)
        {
            _mapper = mapper;
            _unidad = new UnidadDeTrabajo(contexto);
        }

        public void EliminarFactura(Guid id)
        {
            _unidad.facturaRepository.Eliminar(id);
            _unidad.Complete();
        }

        public void ConfirmarPago(Guid IdPedido)
        {
            var pedido = _unidad.pedidoRepository.ObtenerPorId(IdPedido);
            pedido.OrdenPedido = _unidad.ordenPedidoRepository.ObtenerPorId(pedido.OrdenPedidoId);
            pedido.EstadoPago = "Pagado";
            Random numeroComprobante = new Random();
            if (pedido.OrdenPedido.DeseaFactura)
            {
                Factura nuevaFactura = new Factura(pedido, DateTime.Now, 0, numeroComprobante.Next(300000000, 400000000), IdPedido);
                _unidad.facturaRepository.Guardar(nuevaFactura);
            }
            _unidad.pedidoRepository.Actualizar(pedido);
            _unidad.Complete();
        }

        public FacturaDTO ObtenerPorIdFactura(Guid id)
        {
            var factura = _unidad.facturaRepository.ObtenerPorId(id);
            factura.Pedido = _unidad.pedidoRepository.ObtenerPorId(factura.PedidoId);
            factura.Pedido.OrdenPedido = _unidad.ordenPedidoRepository.ObtenerPorId(factura.Pedido.OrdenPedidoId);
            factura.Pedido.OrdenPedido.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaClienteId);
            factura.Pedido.OrdenPedido.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.NITId);
            factura.Pedido.OrdenPedido.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.RubroId);
            factura.Pedido.OrdenPedido.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.ResponsableId);
            factura.Pedido.OrdenPedido.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.Responsable.UsuarioId);
            factura.Pedido.OrdenPedido.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidoraId);
            factura.Pedido.OrdenPedido.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.NITId);
            factura.Pedido.OrdenPedido.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.RubroId);
            factura.Pedido.OrdenPedido.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.ResponsableId);
            factura.Pedido.OrdenPedido.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.Responsable.UsuarioId);
            factura.Pedido.ConductorAsignado = _unidad.asignacionVechiculoConductorRepository.ObtenerPorId(factura.Pedido.ConductorAsignadoId);
            
            return _mapper.Map<FacturaDTO>(factura);
        }

        public IList<FacturaDTO> ObtenerTodoFactura()
        {
            var facturas = _unidad.facturaRepository.ObtenerTodo();
            foreach (var factura in facturas)
            {
                factura.Pedido = _unidad.pedidoRepository.ObtenerPorId(factura.PedidoId);
                factura.Pedido.OrdenPedido = _unidad.ordenPedidoRepository.ObtenerPorId(factura.Pedido.OrdenPedidoId);
                factura.Pedido.OrdenPedido.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaClienteId);
                factura.Pedido.OrdenPedido.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.NITId);
                factura.Pedido.OrdenPedido.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.RubroId);
                factura.Pedido.OrdenPedido.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.ResponsableId);
                factura.Pedido.OrdenPedido.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaCliente.Responsable.UsuarioId);
                factura.Pedido.OrdenPedido.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidoraId);
                factura.Pedido.OrdenPedido.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.NITId);
                factura.Pedido.OrdenPedido.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.RubroId);
                factura.Pedido.OrdenPedido.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.ResponsableId);
                factura.Pedido.OrdenPedido.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(factura.Pedido.OrdenPedido.EmpresaDistribuidora.Responsable.UsuarioId);
                factura.Pedido.ConductorAsignado = _unidad.asignacionVechiculoConductorRepository.ObtenerPorId(factura.Pedido.ConductorAsignadoId);

            }
            return _mapper.Map<List<FacturaDTO>>(facturas);
        }

    }
}
