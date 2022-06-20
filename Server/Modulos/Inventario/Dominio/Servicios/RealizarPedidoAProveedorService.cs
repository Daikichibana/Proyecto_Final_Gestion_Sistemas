using AutoMapper;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class RealizarPedidoAProveedorService : IRealizarPedidoAProveedorService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidadDeTrabajo;
        IActualizarStockPorCompraService _actualizarStockPorCompraService;

        public RealizarPedidoAProveedorService(IMapper mapper, BaseDatosContext context, IActualizarStockPorCompraService actualizarStockPorCompraService)
        {
            _mapper = mapper;
            _unidadDeTrabajo = new UnidadDeTrabajo(context);
            _actualizarStockPorCompraService = actualizarStockPorCompraService;
        }

        public void realizarPedidoProveedor(NotaRecepcionDTO notaRecepcionDTO)
        {
            var listaStock = new List<Stock>();
            var nota = _mapper.Map<NotaRecepcion>(notaRecepcionDTO);
            var detalles = _unidadDeTrabajo.detalleNotaRecepcionRepository.ObtenerTodo().Where(p => p.NotaRecepcionId.Equals(nota.Id)).ToList();

            var notaRegistrada = _unidadDeTrabajo.notaRecepcionRepository.Guardar(nota);
            foreach(var detalle in detalles)
            {
                var stockProducto = _mapper.Map<Stock>(_actualizarStockPorCompraService.ObtenerPorIdStock(detalle.StockId));
                var cantidad = stockProducto.Cantidad += detalle.Cantidad;

                var nuevoDetalle = new DetalleNotaRecepcion(null, null, cantidad, notaRegistrada.Id, stockProducto.Id);
                listaStock.Add(stockProducto);
                _unidadDeTrabajo.detalleNotaRecepcionRepository.Guardar(nuevoDetalle);
            }

            foreach(var stock in listaStock)
            {
                _unidadDeTrabajo.stockRepository.Actualizar(stock);
            }

            _unidadDeTrabajo.Complete();


        }

        
    }
}
