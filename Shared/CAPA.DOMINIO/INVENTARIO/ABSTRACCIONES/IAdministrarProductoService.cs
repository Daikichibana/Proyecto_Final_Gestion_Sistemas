using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.INVENTARIO.ABSTRACCIONES
{
    public interface IAdministrarProductoService
    {
        void Eliminar(Guid id);
        IList<Producto> ObtenerTodo();
        Producto ObtenerPorId(Guid id);
        Producto Guardar(Producto entity);
        Producto Actualizar(Producto entity);
    }
}
