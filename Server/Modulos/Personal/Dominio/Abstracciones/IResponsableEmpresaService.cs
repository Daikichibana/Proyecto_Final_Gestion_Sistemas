using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IResponsableEmpresaService
    {
        void EliminarResponsableEmpresa(Guid id);
        IList<ResponsableEmpresa> ObtenerTodoResponsableEmpresa();
        ResponsableEmpresa ObtenerPorIdResponsableEmpresa(Guid id);
        ResponsableEmpresa GuardarResponsableEmpresa(ResponsableEmpresa entity);
        ResponsableEmpresa ActualizarResponsableEmpresa(ResponsableEmpresa entity);
    }
}
