using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarRolService
    {
        void Eliminar(Guid id);
        IList<Rol> ObtenerTodo();
        Rol ObtenerPorId(Guid id);
        Rol Guardar(Rol entity);
        Rol Actualizar(Rol entity);
    }
}
