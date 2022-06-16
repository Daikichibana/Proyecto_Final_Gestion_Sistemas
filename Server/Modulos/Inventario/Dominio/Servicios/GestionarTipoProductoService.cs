using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class GestionarTipoProductoService : IGestionarTipoProductoService
    {
        ITipoProductoRepository _tipoProductoRepository;

        public GestionarTipoProductoService(ITipoProductoRepository tipoProductoRepository)
        {
            _tipoProductoRepository = tipoProductoRepository;
        }

        public TipoProducto ActualizarTipoProducto(TipoProducto entity)
        {
            return _tipoProductoRepository.Actualizar(entity);
        }

        public void EliminarTipoProducto(Guid id)
        {
            _tipoProductoRepository.Eliminar(id);
        }

        public TipoProducto GuardarTipoProducto(TipoProducto entity)
        {
            return _tipoProductoRepository.Guardar(entity);
        }

        public TipoProducto ObtenerPorIdTipoProducto(Guid id)
        {
            return _tipoProductoRepository.ObtenerPorId(id);
        }

        public IList<TipoProducto> ObtenerTodoTipoProducto()
        {
            return _tipoProductoRepository.ObtenerTodo();
        }
    }
}
