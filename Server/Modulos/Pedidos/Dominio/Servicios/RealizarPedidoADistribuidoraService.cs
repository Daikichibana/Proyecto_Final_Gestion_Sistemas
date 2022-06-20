using AutoMapper;
using Compartido.Dto.Inventario.General;
using Compartido.Dto.Pedidos;
using Compartido.Dto.Pedidos.General;
using Microsoft.EntityFrameworkCore.Storage;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarPedidoADistribuidoraService : IRealizarPedidoADistribuidoraService
    {
        IMapper _mapper;
        IActualizarStockPorCompraService _actualizarStockPorCompraService;
        BaseDatosContext _context;
        UnidadDeTrabajo _unidad;
        public RealizarPedidoADistribuidoraService(BaseDatosContext contexto, IMapper mapper, IActualizarStockPorCompraService actualizarStockPorCompraService, IDetalleOrdenPedidoRepository detalleOrdenPedidoRepository, IOrdenPedidoRepository ordenRepository)
        {
            _mapper = mapper;
            _context = contexto;
            _unidad = new UnidadDeTrabajo(_context);
            _actualizarStockPorCompraService = actualizarStockPorCompraService;
        }

        public void RealizarOrdenPedido(RegistroPedidoDTO pedido)
        {

            List<Stock> ListaStock = new List<Stock>();
            var ordenConvertido = new OrdenPedido(null, pedido.DeseaFactura, pedido.PedidoConfirmado, pedido.AclaracionCliente, pedido.AclaracionDistribuidor, pedido.MetodoPago, null, pedido.EmpresaClienteId, pedido.EmpresaDistribuidoraId);

            var ordenRegistrado = _unidad.ordenRepository.Guardar(ordenConvertido);

            foreach (var detalle in pedido.DetallesOrdenes)
            {
                var StockProducto = _mapper.Map<Stock>(_actualizarStockPorCompraService.ObtenerPorIdStock(detalle.Id));
                StockProducto.CantidadPedida += detalle.CantidadOrdenada;

                DetalleOrdenPedido nuevoDetalle = new DetalleOrdenPedido(null, null, detalle.CantidadOrdenada, ordenRegistrado.Id, StockProducto.Id);


                ListaStock.Add(StockProducto);
                _unidad.detalleOrdenPedidoRepository.Guardar(nuevoDetalle);
            }

            foreach (var stock in ListaStock)
            {
                _unidad.stockRepository.Actualizar(stock);
            }

            _unidad.Complete();
        }

    }
}
