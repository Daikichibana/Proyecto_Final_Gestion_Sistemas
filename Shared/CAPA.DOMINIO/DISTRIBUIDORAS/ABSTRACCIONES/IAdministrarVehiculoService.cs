using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES
{
    public interface IAdministrarVehiculoService
    {
        void Eliminar(Guid id);
        IList<Vechiculo> ObtenerTodo();
        Vechiculo ObtenerPorId(Guid id);
        Vechiculo Guardar(Vechiculo entity);
        Vechiculo Actualizar(Vechiculo entity);
    }
}
