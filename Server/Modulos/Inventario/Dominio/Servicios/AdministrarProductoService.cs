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
        IMapper _mapper;
        public AdministrarProductoService(IMapper mapper, IUsuarioRepository usuarioRepository, IRubroRepository rubroRepository, IResponsableEmpresaRepository responsableEmpresaRepository, INITRepository nitRepository, IEmpresaDistribuidoraRepository distribuidoraRepository, ITipoProductoRepository tipoProductoRepository, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _rubroRepository = rubroRepository;
            _nitRepository = nitRepository;
            _responsableEmpresaRepository = responsableEmpresaRepository;
            _distribuidoraRepository = distribuidoraRepository;
            _tipoProductoRepository = tipoProductoRepository;
            _productoRepository = productoRepository;
        }

        public ProductoDTO ActualizarProducto(ProductoDTO entity)
        {
            var producto = _mapper.Map<Producto>(entity);
            return _mapper.Map<ProductoDTO>(_productoRepository.Actualizar(producto));
        }
        public void EliminarProducto(Guid id)
        {
            _productoRepository.Eliminar(id);
        }
        public ProductoDTO GuardarProducto(ProductoDTO entity)
        {
            var producto = _mapper.Map<Producto>(entity);
            return _mapper.Map<ProductoDTO>(_productoRepository.Guardar(producto));
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
