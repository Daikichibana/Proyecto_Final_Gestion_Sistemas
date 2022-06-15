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

        public Stock Actualizar(Stock entity)
        {
            return _stockRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _stockRepository.Eliminar(id);
        }

        public Stock Guardar(Stock entity)
        {
            return _stockRepository.Guardar(entity);
        }

        public Stock ObtenerPorId(Guid Id)
        {
            return _stockRepository.ObtenerPorId(Id);
        }

        public IList<Stock> ObtenerTodo()
        {
            return _stockRepository.ObtenerTodo();
        }

    }
}
