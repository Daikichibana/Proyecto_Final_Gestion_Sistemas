using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarRolService
    {
        void EliminarRol(Guid id);
        IList<Rol> ObtenerTodoRol();
        Rol ObtenerPorIdRol(Guid id);
        Rol GuardarRol(Rol entity);
        Rol ActualizarRol(Rol entity);
    }
}
