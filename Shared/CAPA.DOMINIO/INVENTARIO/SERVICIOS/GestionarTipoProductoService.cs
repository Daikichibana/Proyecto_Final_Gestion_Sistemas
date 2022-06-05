using CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.TECNICA.INVENTARIO;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.INVENTARIO.SERVICIOS
{
    public class GestionarTipoProductoService : IGestionarTipoProductoService
    {
        ITipoProductoRepository _tipoProductoRepository;

        public GestionarTipoProductoService(ITipoProductoRepository tipoProductoRepository)
        {
            _tipoProductoRepository = tipoProductoRepository;
        }

        public TipoProducto Actualizar(TipoProducto entity)
        {
            return _tipoProductoRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _tipoProductoRepository.Eliminar(id);
        }

        public TipoProducto Guardar(TipoProducto entity)
        {
            return _tipoProductoRepository.Guardar(entity);
        }

        public TipoProducto ObtenerPorId(Guid id)
        {
            return _tipoProductoRepository.ObtenerPorId(id);
        }

        public IList<TipoProducto> ObtenerTodo()
        {
            return _tipoProductoRepository.ObtenerTodo();
        }
    }
}
