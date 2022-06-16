using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IGestionarTipoProductoService
    {
        void EliminarTipoProducto(Guid id);
        IList<TipoProducto> ObtenerTodoTipoProducto();
        TipoProducto ObtenerPorIdTipoProducto(Guid id);
        TipoProducto GuardarTipoProducto(TipoProducto entity);
        TipoProducto ActualizarTipoProducto(TipoProducto entity);
    }
}
