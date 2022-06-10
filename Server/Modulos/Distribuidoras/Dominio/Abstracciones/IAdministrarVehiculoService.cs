using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Abstracciones
{
    public interface IAdministrarVehiculoService
    {
        void Eliminar(Guid id);
        IList<Vechiculo> ObtenerTodo();
        Vechiculo ObtenerPorId(Guid id);
        Vechiculo Guardar(Vechiculo entity);
        Vechiculo Actualizar(Vechiculo entity);
    }
}
