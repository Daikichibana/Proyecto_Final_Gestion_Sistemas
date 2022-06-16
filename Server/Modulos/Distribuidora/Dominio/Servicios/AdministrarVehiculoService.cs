using System;
using System.Collections.Generic;
using System.Linq;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarVehiculoService : IAdministrarVehiculoService
    {
        IVehiculoRepository _vehiculoRepository;
        IAsignacionVechiculoConductorRepository _vehiculoConductorRepository;
        public AdministrarVehiculoService(IAsignacionVechiculoConductorRepository vehiculoConductor, IVehiculoRepository vehiculoRepository)
        {
            _vehiculoConductorRepository = vehiculoConductor;
            _vehiculoRepository = vehiculoRepository;
        }
        public Vechiculo ActualizarVehiculo(Vechiculo entity)
        {
            return _vehiculoRepository.Actualizar(entity);
        }
        public void EliminarVehiculo(Guid id)
        {
           _vehiculoRepository.Eliminar(id);
        }
        public Vechiculo GuardarVehiculo(Vechiculo entity)
        {
            return _vehiculoRepository.Guardar(entity);
        }
        public Vechiculo ObtenerPorIdVehiculo(Guid id)
        {
            return _vehiculoRepository.ObtenerPorId(id);
        }
        public IList<Vechiculo> ObtenerTodoVehiculo()
        {
            return _vehiculoRepository.ObtenerTodo();
        }
        public void AsignarVehiculoAConductor(AsignacionVechiculoConductor vhconductor)
        {
            _vehiculoConductorRepository.Guardar(vhconductor);
        }

        public IList<AsignacionVechiculoConductor> ObtenerTodoAsignacionVechiculo()
        {
            return _vehiculoConductorRepository.ObtenerTodo();
        }
    }
}
