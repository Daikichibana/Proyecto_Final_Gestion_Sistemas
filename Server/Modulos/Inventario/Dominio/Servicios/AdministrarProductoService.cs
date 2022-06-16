using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class AdministrarProductoService: IAdministrarProductoService
    {
        IProductoRepository _productoRepository;

        public AdministrarProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Producto ActualizarProducto(Producto entity)
        {
            return _productoRepository.Actualizar(entity);
        }
        public void EliminarProducto(Guid id)
        {
            _productoRepository.Eliminar(id);
        }
        public Producto GuardarProducto(Producto entity)
        {
            return _productoRepository.Guardar(entity);
        }
        public Producto ObtenerPorIdProducto(Guid id)
        {
            return _productoRepository.ObtenerPorId(id);
        }
        public IList<Producto> ObtenerTodoProducto()
        {
            return _productoRepository.ObtenerTodo();
        }
    }
}
