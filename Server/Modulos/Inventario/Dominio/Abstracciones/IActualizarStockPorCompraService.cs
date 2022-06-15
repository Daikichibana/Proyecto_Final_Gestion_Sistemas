using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IActualizarStockPorCompraService
    {
        void Eliminar(Guid id);
        IList<Stock> ObtenerTodo();
        Stock ObtenerPorId(Guid Id);
        Stock Guardar(Stock entity);
        Stock Actualizar(Stock entity);
    }
}
