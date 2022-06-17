using AutoMapper;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class ActualizarStockPorCompraService : IActualizarStockPorCompraService
    {
        IProductoRepository _productoRepository;
        ITipoProductoRepository _tipoProductoRepository;
        IStockRepository _stockRepository;
        IEmpresaDistribuidoraRepository _distribuidoraRepository;
        IResponsableEmpresaRepository _responsableDistribuidoraRepository;
        INITRepository _nitRepository;
        IRubroRepository _rubroRepository;
        IUsuarioRepository _usuarioRepository;
        IMapper _mapper;
        public ActualizarStockPorCompraService(IMapper mapper, IUsuarioRepository usuarioRepository, IEmpresaDistribuidoraRepository distribuidoraRepository, IResponsableEmpresaRepository responsableEmpresaRepository, INITRepository nITRepository, IRubroRepository rubroRepository, ITipoProductoRepository tipoProductoRepository, IProductoRepository productoRepository, IStockRepository stockRepository)
        {
            _tipoProductoRepository = tipoProductoRepository;
            _productoRepository = productoRepository;
            _stockRepository = stockRepository;
            _distribuidoraRepository = distribuidoraRepository;
            _responsableDistribuidoraRepository = responsableEmpresaRepository;
            _nitRepository = nITRepository;
            _rubroRepository = rubroRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public IList<StockDTO> ActualizarStock(IList<StockDTO> entity)
        {
            var result = new List<Stock>();
            var ListaStock = _mapper.Map<List<Stock>>(entity);
            
            foreach (var stock in ListaStock)
            { 
                var stockActualizado = _stockRepository.Actualizar(stock);
                result.Add(stockActualizado);
            }

            _stockRepository.GuardarCambios();

            return _mapper.Map<List<StockDTO>>(result);
        }

        public StockDTO ObtenerPorIdStock(Guid Id)
        {
            var stock = _stockRepository.ObtenerPorId(Id);
            stock.Producto = _productoRepository.ObtenerPorId(stock.ProductoId);
            stock.Producto.EmpresaDistribuidora = _distribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidoraId);
            stock.Producto.EmpresaDistribuidora.NIT = _nitRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.NITId);
            stock.Producto.EmpresaDistribuidora.Responsable = _responsableDistribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.ResponsableId);
            stock.Producto.EmpresaDistribuidora.Rubro = _rubroRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.RubroId);
            stock.Producto.EmpresaDistribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.Responsable.UsuarioId);
            stock.Producto.TipoProducto = _tipoProductoRepository.ObtenerPorId(stock.Producto.TipoProductoId);

            return _mapper.Map<StockDTO>(stock);
        }

        public IList<StockDTO> ObtenerTodoStock()
        {
            var ListaStock = _stockRepository.ObtenerTodo();

            foreach (var stock in ListaStock) 
            {
                stock.Producto = _productoRepository.ObtenerPorId(stock.ProductoId);
                stock.Producto.EmpresaDistribuidora = _distribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidoraId);
                stock.Producto.EmpresaDistribuidora.NIT = _nitRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.NITId);
                stock.Producto.EmpresaDistribuidora.Responsable = _responsableDistribuidoraRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.ResponsableId);
                stock.Producto.EmpresaDistribuidora.Rubro = _rubroRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.RubroId);
                stock.Producto.EmpresaDistribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(stock.Producto.EmpresaDistribuidora.Responsable.UsuarioId);
                stock.Producto.TipoProducto = _tipoProductoRepository.ObtenerPorId(stock.Producto.TipoProductoId);
            }

            return _mapper.Map<List<StockDTO>>(ListaStock);
        }

    }
}
