using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Inventario.General;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class AdministrarProductoService : IAdministrarProductoService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public AdministrarProductoService(IMapper mapper, BaseDatosContext context)
        {
            _mapper = mapper;
            _unidad = new UnidadDeTrabajo(context);
        }

        public IList<ProductoDTO> ActualizarProducto(IList<ProductoDTO> entity)
        {
            var productos = _mapper.Map<List<Producto>>(entity);
            var productosActualizados = new List<Producto>();

            foreach (var producto in productos)
            {
                var ProductoExistente = _unidad.productoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(producto.Nombre)).ToList();

                if (ProductoExistente.Count > 0)
                    if (!ProductoExistente.FirstOrDefault().Id.Equals(producto.Id))
                        throw new Exception("Ya existe otro producto con el mismo nombre.");

                var productoActualizado = _unidad.productoRepository.Actualizar(producto);
                productosActualizados.Add(productoActualizado);
            }

            _unidad.Complete();
            return _mapper.Map<List<ProductoDTO>>(productosActualizados);
        }
        public void EliminarProducto(List<Guid> id)
        {
            foreach (var idProducto in id)
            {
                var stock = _unidad.stockRepository.ObtenerTodo().Where(p => p.ProductoId.Equals(idProducto)).FirstOrDefault();
                if (stock != null)
                {
                    _unidad.stockRepository.Eliminar(stock.Id);
                }
                _unidad.productoRepository.Eliminar(idProducto);
            }

            _unidad.Complete();
        }
        public IList<ProductoDTO> GuardarProducto(IList<ProductoDTO> entity)
        {
            var productos = _mapper.Map<List<Producto>>(entity);
            var productosRegistrados = new List<Producto>();
            foreach (var producto in productos)
            {
                var productoExistente = _unidad.productoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(producto.Nombre)).ToList();

                if (productoExistente.Count > 0)
                    throw new Exception("Un producto con el mismo nombre ya se encuentra registrado.");

                var productoRegistrado = _unidad.productoRepository.Guardar(producto);
                productosRegistrados.Add(productoRegistrado);

                Stock nuevoStock = new Stock(producto, 0, 0, 0, 0, 0, productoRegistrado.Id);

                if (nuevoStock.Producto == null || nuevoStock.ProductoId == Guid.Empty)
                    throw new Exception("No se puede registrar el stock por que faltan datos del producto.");

                _unidad.stockRepository.Guardar(nuevoStock);
            }

            _unidad.Complete();
            return _mapper.Map<List<ProductoDTO>>(productosRegistrados);
        }
        public ProductoDTO ObtenerPorIdProducto(Guid id)
        {
            var producto = _unidad.productoRepository.ObtenerPorId(id);

            producto.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(producto.EmpresaDistribuidoraId);
            producto.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(producto.EmpresaDistribuidora.NITId);
            producto.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(producto.EmpresaDistribuidora.ResponsableId);
            producto.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(producto.EmpresaDistribuidora.Responsable.UsuarioId);
            producto.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(producto.EmpresaDistribuidora.RubroId);
            producto.TipoProducto = _unidad.tipoProductoRepository.ObtenerPorId(producto.TipoProductoId);

            return _mapper.Map<ProductoDTO>(producto);
        }
        public IList<ProductoDTO> ObtenerTodoProducto()
        {
            var producto = _unidad.productoRepository.ObtenerTodo();

            foreach (var item in producto)
            {
                item.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(item.EmpresaDistribuidoraId);
                item.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(item.EmpresaDistribuidora.NITId);
                item.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(item.EmpresaDistribuidora.ResponsableId);
                item.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(item.EmpresaDistribuidora.Responsable.UsuarioId);
                item.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(item.EmpresaDistribuidora.RubroId);
                item.TipoProducto = _unidad.tipoProductoRepository.ObtenerPorId(item.TipoProductoId);
            }
            
            return _mapper.Map<IList<ProductoDTO>>(producto);
        }

        public IList<ProductoDTO> ObtenerTodoProductoPorIdEmpresa(Guid IdEmpresa)
        {
            return _mapper.Map<List<ProductoDTO>>(_unidad.productoRepository.ObtenerTodo().Where(p => p.EmpresaDistribuidoraId.Equals(IdEmpresa)));
        }
    }
}
