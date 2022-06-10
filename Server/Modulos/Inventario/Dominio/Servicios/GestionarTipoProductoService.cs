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
