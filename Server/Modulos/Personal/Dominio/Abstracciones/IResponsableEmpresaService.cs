using System;
using System.Collections.Generic;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IResponsableEmpresaService
    {
        void EliminarResponsableEmpresa(Guid id);
        IList<ResponsableEmpresaDTO> ObtenerTodoResponsableEmpresa();
        ResponsableEmpresaDTO ObtenerPorIdResponsableEmpresa(Guid id);
        ResponsableEmpresaDTO GuardarResponsableEmpresa(ResponsableEmpresaDTO entity);
        ResponsableEmpresaDTO ActualizarResponsableEmpresa(ResponsableEmpresaDTO entity);
    }
}
