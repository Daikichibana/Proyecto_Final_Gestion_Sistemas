using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IActualizarStockPorCompraService
    {
        void EliminarStock(Guid id);
        IList<Stock> ObtenerTodoStock();
        Stock ObtenerPorIdStock(Guid Id);
        Stock GuardarStock(Stock entity);
        Stock ActualizarStock(Stock entity);
    }
}
