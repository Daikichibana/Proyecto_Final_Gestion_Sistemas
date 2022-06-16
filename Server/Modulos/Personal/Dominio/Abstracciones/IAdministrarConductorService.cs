using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarConductorService
    {
        void EliminarConductor(Guid id);
        IList<Conductor> ObtenerTodoConductor();
        Conductor ObtenerPorIdConductor(Guid id);
        Conductor GuardarConductor(Conductor entity);
        Conductor ActualizarConductor(Conductor entity);

    }
}
