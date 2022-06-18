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
        UnidadDeTrabajo _unidad;
        public GestionarTipoProductoService(IMapper mapper, BaseDatosContext context)
        {
            _mapper = mapper;
            _unidad = new UnidadDeTrabajo(context);
        }

        public IList<TipoProductoDTO> ActualizarTipoProducto(IList<TipoProductoDTO> entity)
        {
            var tipoProductos = _mapper.Map<List<TipoProducto>>(entity);
            var result = new List<TipoProducto>();

            foreach (var tipoProducto in tipoProductos)
            {
                var tipoProductoExistente = _unidad.tipoProductoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(tipoProducto.Nombre)).ToList();

                if (tipoProductoExistente.Count > 0)
                {
                    if (!tipoProducto.Id.Equals(tipoProductoExistente.FirstOrDefault().Id))
                        throw new Exception("El tipo de producto ya se encuentra registrado.");
                }

                result.Add(_unidad.tipoProductoRepository.Actualizar(tipoProducto));
            }

            _unidad.tipoProductoRepository.GuardarCambios();

            return _mapper.Map<List<TipoProductoDTO>>(result);
        }

        public void EliminarTipoProducto(IList<Guid> id)
        {
            foreach (var idTipoProducto in id)
            {
                var productoExistente = _unidad.productoRepository.ObtenerTodo().Where(p => p.Id.Equals(idTipoProducto)).ToList();

                if (productoExistente.Count > 0)
                    throw new Exception("El tipo de producto no puede ser eliminado ya que tiene asociado uno o mas productos.");

                _unidad.tipoProductoRepository.Eliminar(idTipoProducto);
            }

            _unidad.Complete();
        }

        public IList<TipoProductoDTO> GuardarTipoProducto(IList<TipoProductoDTO> entity)
        {
            var tipoProductos = _mapper.Map<List<TipoProducto>>(entity);
            var result = new List<TipoProducto>();

            foreach (var tipoProducto in tipoProductos)
            {
                var tipoProductoExistente = _unidad.tipoProductoRepository.ObtenerTodo().Where(p => p.Nombre.Equals(tipoProducto.Nombre)).ToList();

                if (tipoProductoExistente.Count > 0)
                {
                    throw new Exception("El tipo de producto ya se encuentra registrado.");
                }

                result.Add(_unidad.tipoProductoRepository.Guardar(tipoProducto));
            }

            _unidad.Complete();

            return _mapper.Map<List<TipoProductoDTO>>(result);
        }

        public TipoProductoDTO ObtenerPorIdTipoProducto(Guid id)
        {
            return _mapper.Map<TipoProductoDTO>(_unidad.tipoProductoRepository.ObtenerPorId(id));
        }

        public IList<TipoProductoDTO> ObtenerTodoTipoProducto()
        {
            return _mapper.Map<IList<TipoProductoDTO>>(_unidad.tipoProductoRepository.ObtenerTodo());
        }
    }
}
