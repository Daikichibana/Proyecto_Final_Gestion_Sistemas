using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class GestionarTipoProductoService : IGestionarTipoProductoService
    {
        IMapper _mapper;
        ITipoProductoRepository _tipoProductoRepository;
        IProductoRepository _productoRepository;
        public GestionarTipoProductoService(IMapper mapper, ITipoProductoRepository tipoProductoRepository, IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _tipoProductoRepository = tipoProductoRepository;
            _productoRepository = productoRepository;
        }

        public IList<TipoProductoDTO> ActualizarTipoProducto(IList<TipoProductoDTO> entity)
        {
            var tipoProductos = _mapper.Map<List<TipoProducto>>(entity);
            var result = new List<TipoProducto>();

            foreach (var tipoProducto in tipoProductos)
            {
                var tipoProductoExistente = _tipoProductoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(tipoProducto.Nombre)).ToList();

                if (tipoProductoExistente.Count > 0)
                {
                    if (!tipoProducto.Id.Equals(tipoProductoExistente.FirstOrDefault().Id))
                        throw new Exception("El tipo de producto ya se encuentra registrado.");
                }

                result.Add(_tipoProductoRepository.Actualizar(tipoProducto));
            }

            _tipoProductoRepository.GuardarCambios();

            return _mapper.Map<List<TipoProductoDTO>>(result);
        }

        public void EliminarTipoProducto(IList<Guid> id)
        {
            foreach (var idTipoProducto in id)
            {
                var productoExistente = _productoRepository.ObtenerTodo().Where(p => p.Id.Equals(idTipoProducto)).ToList();

                if (productoExistente.Count > 0)
                    throw new Exception("El tipo de producto no puede ser eliminado ya que tiene asociado uno o mas productos.");

                _tipoProductoRepository.Eliminar(idTipoProducto);
            }

            _tipoProductoRepository.GuardarCambios();
        }

        public IList<TipoProductoDTO> GuardarTipoProducto(IList<TipoProductoDTO> entity)
        {
            var tipoProductos = _mapper.Map<List<TipoProducto>>(entity);
            var result = new List<TipoProducto>();

            foreach (var tipoProducto in tipoProductos)
            {
                var tipoProductoExistente = _tipoProductoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(tipoProducto.Nombre)).ToList();

                if (tipoProductoExistente.Count > 0)
                {
                    throw new Exception("El tipo de producto ya se encuentra registrado.");
                }

                result.Add(_tipoProductoRepository.Guardar(tipoProducto));
            }

            _tipoProductoRepository.GuardarCambios();

            return _mapper.Map<List<TipoProductoDTO>>(result);
        }

        public TipoProductoDTO ObtenerPorIdTipoProducto(Guid id)
        {
            return _mapper.Map<TipoProductoDTO>(_tipoProductoRepository.ObtenerPorId(id));
        }

        public IList<TipoProductoDTO> ObtenerTodoTipoProducto()
        {
            return _mapper.Map<IList<TipoProductoDTO>>(_tipoProductoRepository.ObtenerTodo());
        }
    }
}
