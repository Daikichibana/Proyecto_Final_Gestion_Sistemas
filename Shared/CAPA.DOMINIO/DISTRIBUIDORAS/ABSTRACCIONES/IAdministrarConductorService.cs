using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES
{
    public interface IAdministrarConductorService
    {
        void Eliminar(Guid id);
        IList<Conductor> ObtenerTodo();
        Conductor ObtenerPorId(Guid id);
        Conductor Guardar(Conductor entity);
        Conductor Actualizar(Conductor entity);
    }
}
