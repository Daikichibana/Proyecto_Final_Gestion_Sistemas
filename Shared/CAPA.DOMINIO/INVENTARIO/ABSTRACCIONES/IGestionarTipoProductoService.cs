using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES
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
