using System;
using System.Collections.Generic;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarRolService
    {
        void EliminarRol(Guid id);
        IList<RolDTO> ObtenerTodoRol();
        RolDTO ObtenerPorIdRol(Guid id);
        RolDTO GuardarRol(RolDTO entity);
        RolDTO ActualizarRol(RolDTO entity);
    }
}
