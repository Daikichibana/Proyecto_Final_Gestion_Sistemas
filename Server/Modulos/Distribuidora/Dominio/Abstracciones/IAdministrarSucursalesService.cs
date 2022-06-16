using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarSucursalesService
    {
        void EliminarSucursales(Guid id);
        IList<Sucursales> ObtenerTodoSucursales();
        Sucursales ObtenerPorIdSucursales(Guid id);
        Sucursales GuardarSucursales(Sucursales entity);
        Sucursales ActualizarSucursales(Sucursales entity);
    }
}
