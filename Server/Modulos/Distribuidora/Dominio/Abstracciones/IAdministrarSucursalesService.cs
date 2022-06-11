using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarSucursalesService
    {
        void Eliminar(Guid id);
        IList<Sucursales> ObtenerTodo();
        Sucursales ObtenerPorId(Guid id);
        Sucursales Guardar(Sucursales entity);
        Sucursales Actualizar(Sucursales entity);
    }
}
