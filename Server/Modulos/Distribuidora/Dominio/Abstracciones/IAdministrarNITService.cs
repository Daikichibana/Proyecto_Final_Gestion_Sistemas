using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarNITService
    {
        void EliminarNIT(Guid id);
        IList<NIT> ObtenerTodoNIT();
        NIT ObtenerPorIdNIT(Guid id);
        NIT GuardarNIT(NIT entity);
        NIT ActualizarNIT(NIT entity);
    }
}
