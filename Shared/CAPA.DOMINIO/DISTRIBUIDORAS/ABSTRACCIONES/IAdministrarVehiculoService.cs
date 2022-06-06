using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES
{
    public interface IAdministrarVehiculoService
    {
        void Eliminar(Guid id);
        IList<Vehiculo> ObtenerTodo();
        Vehiculo ObtenerPorId(Guid id);
        Vehiculo Guardar(Vehiculo entity);
        Vehiculo Actualizar(Vehiculo entity);
    }
}
