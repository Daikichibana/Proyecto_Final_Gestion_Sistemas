using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarVehiculoService
    {
        void EliminarVehiculo(Guid id);
        IList<VehiculoDTO> ObtenerTodoVehiculo();
        VehiculoDTO ObtenerPorIdVehiculo(Guid id);
        IList<VehiculoDTO> GuardarVehiculo(IList<VehiculoDTO> entity);
        IList<VehiculoDTO> ActualizarVehiculo(IList<VehiculoDTO> entity);
        void AsignarVehiculoAConductor(AsignacionVechiculoConductorDTO vhconductor);
        IList<AsignacionVechiculoConductorDTO> ObtenerTodoAsignacionVechiculo();
    }
}
