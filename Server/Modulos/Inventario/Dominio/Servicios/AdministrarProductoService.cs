using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System.Linq;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using AutoMapper;
using Compartido.Dto.Inventario.General;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class AdministrarProductoService : IAdministrarProductoService
    {
        IProductoRepository _productoRepository;
        ITipoProductoRepository _tipoProductoRepository;
        IEmpresaDistribuidoraRepository _distribuidoraRepository;
        INITRepository _nitRepository;
        IResponsableEmpresaRepository _responsableEmpresaRepository;
        IRubroRepository _rubroRepository;
        IUsuarioRepository _usuarioRepository;
        IStockRepository _stockRepository;
        IMapper _mapper;
        public AdministrarProductoService(IMapper mapper,IStockRepository stockRepository, IUsuarioRepository usuarioRepository, IRubroRepository rubroRepository, IResponsableEmpresaRepository responsableEmpresaRepository, INITRepository nitRepository, IEmpresaDistribuidoraRepository distribuidoraRepository, ITipoProductoRepository tipoProductoRepository, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _stockRepository = stockRepository;
            _usuarioRepository = usuarioRepository;
            _rubroRepository = rubroRepository;
            _nitRepository = nitRepository;
            _responsableEmpresaRepository = responsableEmpresaRepository;
            _distribuidoraRepository = distribuidoraRepository;
            _tipoProductoRepository = tipoProductoRepository;
            _productoRepository = productoRepository;
        }

        public IList<ProductoDTO> ActualizarProducto(IList<ProductoDTO> entity)
        {
            var productos = _mapper.Map<List<Producto>>(entity);
            var productosActualizados = new List<Producto>();

            foreach (var producto in productos)
            {
                var ProductoExistente = _productoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(producto.Nombre)).ToList();

                if (ProductoExistente.Count > 0)
                    if (!ProductoExistente.FirstOrDefault().Id.Equals(producto.Id))
                        throw new Exception("Ya existe otro producto con el mismo nombre.");

                var productoActualizado = _productoRepository.Actualizar(producto);
                productosActualizados.Add(productoActualizado);
            }

            _productoRepository.GuardarCambios();
            return _mapper.Map<List<ProductoDTO>>(productosActualizados);
        }
        public void EliminarProducto(List<Guid> id)
        {
            foreach (var idProducto in id)
            {
                var stock = _stockRepository.ObtenerTodo().Where(p => p.ProductoId.Equals(idProducto)).FirstOrDefault();
                if (stock != null)
                {
                    _stockRepository.Eliminar(stock.Id);
                }
                _productoRepository.Eliminar(idProducto);
            }

            _stockRepository.GuardarCambios();
            _productoRepository.GuardarCambios();
        }
        public IList<ProductoDTO> GuardarProducto(IList<ProductoDTO> entity)
        {
            var productos = _mapper.Map<List<Producto>>(entity);
            var productosRegistrados = new List<Producto>();
            foreach (var producto in productos)
            {
                var productoExistente = _productoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(producto.Nombre)).ToList();

                if (productoExistente.Count > 0)
                    throw new Exception("Un producto con el mismo nombre ya se encuentra registrado.");

                var productoRegistrado = _productoRepository.Guardar(producto);
                productosRegistrados.Add(productoRegistrado);

                Stock nuevoStock = new Stock(producto, 0, 0, 0, 0, 0, productoRegistrado.Id);

                if (nuevoStock.Producto == null || nuevoStock.ProductoId == Guid.Empty)
                    throw new Exception("No se puede registrar el stock por que faltan datos del producto.");

                _stockRepository.Guardar(nuevoStock);
            }

            _productoRepository.GuardarCambios();
            _stockRepository.GuardarCambios();
            
            return _mapper.Map<List<ProductoDTO>>(productosRegistrados);
        }
        public ProductoDTO ObtenerPorIdProducto(Guid id)
        {
            var producto = _productoRepository.ObtenerPorId(id);

            producto.EmpresaDistribuidora = _distribuidoraRepository.ObtenerPorId(producto.EmpresaDistribuidoraId);
            producto.EmpresaDistribuidora.NIT = _nitRepository.ObtenerPorId(producto.EmpresaDistribuidora.NITId);
            producto.EmpresaDistribuidora.Responsable = _responsableEmpresaRepository.ObtenerPorId(producto.EmpresaDistribuidora.ResponsableId);
            producto.EmpresaDistribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(producto.EmpresaDistribuidora.Responsable.UsuarioId);
            producto.EmpresaDistribuidora.Rubro = _rubroRepository.ObtenerPorId(producto.EmpresaDistribuidora.RubroId);
            producto.TipoProducto = _tipoProductoRepository.ObtenerPorId(producto.TipoProductoId);

            return _mapper.Map<ProductoDTO>(producto);
        }
        public IList<ProductoDTO> ObtenerTodoProducto()
        {
            var producto = _productoRepository.ObtenerTodo();

            foreach (var item in producto)
            {
                item.EmpresaDistribuidora = _distribuidoraRepository.ObtenerPorId(item.EmpresaDistribuidoraId);
                item.EmpresaDistribuidora.NIT = _nitRepository.ObtenerPorId(item.EmpresaDistribuidora.NITId);
                item.EmpresaDistribuidora.Responsable = _responsableEmpresaRepository.ObtenerPorId(item.EmpresaDistribuidora.ResponsableId);
                item.EmpresaDistribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(item.EmpresaDistribuidora.Responsable.UsuarioId);
                item.EmpresaDistribuidora.Rubro = _rubroRepository.ObtenerPorId(item.EmpresaDistribuidora.RubroId);
                item.TipoProducto = _tipoProductoRepository.ObtenerPorId(item.TipoProductoId);
            }
            
            return _mapper.Map<IList<ProductoDTO>>(producto);
        }
    }
}
