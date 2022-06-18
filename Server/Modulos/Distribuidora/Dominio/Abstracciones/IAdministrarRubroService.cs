using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarRubroService
    {
        void EliminarRubro(Guid id);
        IList<RubroDTO> ObtenerTodoRubro();
        RubroDTO ObtenerPorIdRubro(Guid id);
        IList<RubroDTO> GuardarRubro(IList<RubroDTO> entity);
        IList<RubroDTO> ActualizarRubro(IList<RubroDTO> entity);
    }
}
