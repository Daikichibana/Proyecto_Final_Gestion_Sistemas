using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES
{
    public interface IAdministrarResponsableAlmacenService
    {
        void Eliminar(Guid id);
        IList<ResponsableAlmacen> ObtenerTodo();
        ResponsableAlmacen ObtenerPorId(Guid id);
        ResponsableAlmacen Guardar(ResponsableAlmacen entity);
        ResponsableAlmacen Actualizar(ResponsableAlmacen entity);
    }
}
