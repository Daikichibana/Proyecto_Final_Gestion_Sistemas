using System;
using System.Collections.Generic;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarResponsableAlmacenService
    {
        void EliminarResponsableAlmacen(Guid id);
        IList<ResponsableAlmacenDTO> ObtenerTodoResponsableAlmacen();
        ResponsableAlmacenDTO ObtenerPorIdResponsableAlmacen(Guid id);
        IList<ResponsableAlmacenDTO> GuardarResponsableAlmacen(IList<ResponsableAlmacenDTO> entity);
        IList<ResponsableAlmacenDTO> ActualizarResponsableAlmacen(IList<ResponsableAlmacenDTO> entity);
    }
}
