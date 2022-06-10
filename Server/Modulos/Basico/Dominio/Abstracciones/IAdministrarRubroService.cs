using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Abstracciones
{
    public interface IAdministrarRubroService
    {
        void Eliminar(Guid id);
        IList<Rubro> ObtenerTodo();
        Rubro ObtenerPorId(Guid id);
        Rubro Guardar(Rubro entity);
        Rubro Actualizar(Rubro entity);
    }
}
