using CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.TECNICA.INVENTARIO;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.INVENTARIO.SERVICIOS
{
    public class AdministrarProductoService: IAdministrarProductoService
    {
        IProductoRepository _productoRepository;

        public AdministrarProductoService(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }

        public Producto Actualizar(Producto entity)
        {
            return _productoRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _productoRepository.Eliminar(id);
        }
        public Producto Guardar(Producto entity)
        {
            return _productoRepository.Guardar(entity);
        }
        public Producto ObtenerPorId(Guid id)
        {
            return _productoRepository.ObtenerPorId(id);
        }
        public IList<Producto> ObtenerTodo()
        {
            return _productoRepository.ObtenerTodo();
        }
    }
}
