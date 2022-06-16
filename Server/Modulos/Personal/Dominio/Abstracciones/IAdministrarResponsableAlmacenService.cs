using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarResponsableAlmacenService
    {
        void EliminarResponsableAlmacen(Guid id);
        IList<ResponsableAlmacen> ObtenerTodoResponsableAlmacen();
        ResponsableAlmacen ObtenerPorIdResponsableAlmacen(Guid id);
        ResponsableAlmacen GuardarResponsableAlmacen(ResponsableAlmacen entity);
        ResponsableAlmacen ActualizarResponsableAlmacen(ResponsableAlmacen entity);
    }
}
