using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Abstracciones
{
    public interface IAdministrarConductorService
    {
        void Eliminar(Guid id);
        IList<Conductor> ObtenerTodo();
        Conductor ObtenerPorId(Guid id);
        Conductor Guardar(Conductor entity);
        Conductor Actualizar(Conductor entity);
    }
}
