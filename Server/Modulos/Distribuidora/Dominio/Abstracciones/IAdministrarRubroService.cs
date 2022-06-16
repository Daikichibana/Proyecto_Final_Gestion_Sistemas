using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarRubroService
    {
        void EliminarRubro(Guid id);
        IList<Rubro> ObtenerTodoRubro();
        Rubro ObtenerPorIdRubro(Guid id);
        Rubro GuardarRubro(Rubro entity);
        Rubro ActualizarRubro(Rubro entity);
    }
}
