using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IActualizarStockPorCompraService
    {
        IList<StockDTO> ObtenerTodoStock();
        StockDTO ObtenerPorIdStock(Guid Id);
        IList<StockDTO> ActualizarStock(IList<StockDTO> entity);
        IList<StockDTO> ObtenerTodoStockPorIdEmpresa(Guid id);
    }
}
