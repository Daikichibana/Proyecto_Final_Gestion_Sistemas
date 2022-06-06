using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES
{
    public interface IAdministrarSucursalesService
    {
        void Eliminar(Guid id);
        IList<Sucursales> ObtenerTodo();
        Sucursales ObtenerPorId(Guid id);
        Sucursales Guardar(Sucursales entity);
        Sucursales Actualizar(Sucursales entity);
    }
}
