using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarVehiculoService : IAdministrarVehiculoService
    {
        IVehiculoRepository _vehiculoRepository;

        public AdministrarVehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }
        public Vechiculo Actualizar(Vechiculo entity)
        {
            return _vehiculoRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
           _vehiculoRepository.Eliminar(id);
        }
        public Vechiculo Guardar(Vechiculo entity)
        {
            return _vehiculoRepository.Guardar(entity);
        }
        public Vechiculo ObtenerPorId(Guid id)
        {
            return _vehiculoRepository.ObtenerPorId(id);
        }
        public IList<Vechiculo> ObtenerTodo()
        {
            return _vehiculoRepository.ObtenerTodo();
        }
    }
}
