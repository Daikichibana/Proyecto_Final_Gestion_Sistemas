using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Abstracciones
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
