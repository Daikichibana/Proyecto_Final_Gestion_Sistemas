using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarNITService
    {
        void EliminarNIT(Guid id);
        IList<NITDTO> ObtenerTodoNIT();
        NITDTO ObtenerPorIdNIT(Guid id);
        NITDTO GuardarNIT(NITDTO entity);
        NITDTO ActualizarNIT(NITDTO entity);
    }
}
