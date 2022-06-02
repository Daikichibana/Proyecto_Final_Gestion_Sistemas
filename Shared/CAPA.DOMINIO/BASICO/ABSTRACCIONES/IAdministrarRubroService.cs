using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES
{
    public interface IAdministrarRubroService
    {
        void Eliminar(Guid id);
        IList<Rubro> ObtenerTodo();
        Rubro ObtenerPorId(int id);
        Rubro Guardar(Rubro entity);
        Rubro Actualizar(Rubro entity);
    }
}
