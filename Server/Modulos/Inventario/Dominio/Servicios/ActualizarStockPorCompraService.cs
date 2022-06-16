using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class ActualizarStockPorCompraService : IActualizarStockPorCompraService
    {
        IProductoRepository _productoRepository;
        IStockRepository _stockRepository;
        public ActualizarStockPorCompraService(IProductoRepository productoRepository, IStockRepository stockRepository)
        {
            _productoRepository = productoRepository;
            _stockRepository = stockRepository;
        }

        public Stock ActualizarStock(Stock entity)
        {
            return _stockRepository.Actualizar(entity);
        }

        public void EliminarStock(Guid id)
        {
            _stockRepository.Eliminar(id);
        }

        public Stock GuardarStock(Stock entity)
        {
            return _stockRepository.Guardar(entity);
        }

        public Stock ObtenerPorIdStock(Guid Id)
        {
            return _stockRepository.ObtenerPorId(Id);
        }

        public IList<Stock> ObtenerTodoStock()
        {
            return _stockRepository.ObtenerTodo();
        }

    }
}
