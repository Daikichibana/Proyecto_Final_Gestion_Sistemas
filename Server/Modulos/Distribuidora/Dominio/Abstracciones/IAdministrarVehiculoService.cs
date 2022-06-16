using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarVehiculoService
    {
        void EliminarVehiculo(Guid id);
        IList<Vechiculo> ObtenerTodoVehiculo();
        Vechiculo ObtenerPorIdVehiculo(Guid id);
        Vechiculo GuardarVehiculo(Vechiculo entity);
        Vechiculo ActualizarVehiculo(Vechiculo entity);
        void AsignarVehiculoAConductor(AsignacionVechiculoConductor vhconductor);
        IList<AsignacionVechiculoConductor> ObtenerTodoAsignacionVechiculo();
    }
}
