using System;
using System.Collections.Generic;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarConductorService
    {
        void EliminarConductor(Guid id);
        IList<ConductorDTO> ObtenerTodoConductor();
        ConductorDTO ObtenerPorIdConductor(Guid id);
        IList<ConductorDTO> GuardarConductor(IList<ConductorDTO> entity);
        IList<ConductorDTO> ActualizarConductor(IList<ConductorDTO> entity);
    }
}
