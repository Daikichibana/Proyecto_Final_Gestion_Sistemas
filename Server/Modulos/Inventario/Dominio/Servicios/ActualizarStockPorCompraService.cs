using AutoMapper;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class ActualizarStockPorCompraService : IActualizarStockPorCompraService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public ActualizarStockPorCompraService(IMapper mapper, BaseDatosContext context)
        {
            _mapper = mapper;
            _unidad = new UnidadDeTrabajo(context);
        }

        public IList<StockDTO> ActualizarStock(IList<StockDTO> entity)
        {
            var result = new List<Stock>();
            var ListaStock = _mapper.Map<List<Stock>>(entity);
            
            foreach (var stock in ListaStock)
            { 
                var stockActualizado = _unidad.stockRepository.Actualizar(stock);
                result.Add(stockActualizado);
            }

            _unidad.Complete();
            return _mapper.Map<List<StockDTO>>(result);
        }

        public StockDTO ObtenerPorIdStock(Guid Id)
        {
            var stock = _unidad.stockRepository.ObtenerPorId(Id);
            stock.Producto = _unidad.productoRepository.ObtenerPorId(stock.ProductoId);
            stock.Producto.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidoraId);
            stock.Producto.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.NITId);
            stock.Producto.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.ResponsableId);
            stock.Producto.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.RubroId);
            stock.Producto.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.Responsable.UsuarioId);
            stock.Producto.TipoProducto = _unidad.tipoProductoRepository.ObtenerPorId(stock.Producto.TipoProductoId);

            return _mapper.Map<StockDTO>(stock);
        }

        public IList<StockDTO> ObtenerTodoStock()
        {
            var ListaStock = _unidad.stockRepository.ObtenerTodo();

            foreach (var stock in ListaStock) 
            {
                stock.Producto = _unidad.productoRepository.ObtenerPorId(stock.ProductoId);
                stock.Producto.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidoraId);
                stock.Producto.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.NITId);
                stock.Producto.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.ResponsableId);
                stock.Producto.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.RubroId);
                stock.Producto.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.Responsable.UsuarioId);
                stock.Producto.TipoProducto = _unidad.tipoProductoRepository.ObtenerPorId(stock.Producto.TipoProductoId);
            }

            return _mapper.Map<List<StockDTO>>(ListaStock);
        }

        public IList<StockDTO> ObtenerTodoStockPorIdEmpresa(Guid id)
        {
            var ListaStock = _unidad.stockRepository.ObtenerTodo();

            foreach (var stock in ListaStock)
            {
                stock.Producto = _unidad.productoRepository.ObtenerPorId(stock.ProductoId);
                stock.Producto.TipoProducto = _unidad.tipoProductoRepository.ObtenerPorId(stock.Producto.TipoProductoId);
                stock.Producto.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidoraId);
                stock.Producto.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.RubroId);
                stock.Producto.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.NITId);
                stock.Producto.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.ResponsableId);
                stock.Producto.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.Responsable.UsuarioId);
            }

            return _mapper.Map<IList<StockDTO>>(ListaStock.Where(p => p.Producto.EmpresaDistribuidoraId.Equals(id)));
        }


    }
}
