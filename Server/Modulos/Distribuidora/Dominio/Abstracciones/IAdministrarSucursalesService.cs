using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarSucursalesService
    {
        void EliminarSucursales(Guid id);
        IList<SucursalesDTO> ObtenerTodoSucursales();
        SucursalesDTO ObtenerPorIdSucursales(Guid id);
        IList<SucursalesDTO> GuardarSucursales(IList<SucursalesDTO> entity);
        IList<SucursalesDTO> ActualizarSucursales(IList<SucursalesDTO> entity);
    }
}
