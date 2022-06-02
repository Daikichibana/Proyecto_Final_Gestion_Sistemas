using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO
{
    public interface IService<T>
    {
        void Eliminar(Guid id);
        IList<T> ObtenerTodo();
        T ObtenerPorId(int id);
        T Guardar(T entity);
        T Actualizar(T entity);
    }
}
