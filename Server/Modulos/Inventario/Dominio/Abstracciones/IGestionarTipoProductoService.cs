using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IGestionarTipoProductoService
    {
        void Eliminar(Guid id);
        IList<TipoProducto> ObtenerTodo();
        TipoProducto ObtenerPorId(Guid id);
        TipoProducto Guardar(TipoProducto entity);
        TipoProducto Actualizar(TipoProducto entity);
    }
}
