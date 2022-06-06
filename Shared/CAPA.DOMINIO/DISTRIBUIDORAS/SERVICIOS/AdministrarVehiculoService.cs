using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS
{
    public class AdministrarVehiculoService : IAdministrarVehiculoService
    {
        IVehiculoRepository _vehiculoRepository;

        public AdministrarVehiculoService(IVehiculoRepository vehiculoRepository)
        {
            _vehiculoRepository = vehiculoRepository;
        }
        public Vehiculo Actualizar(Vehiculo entity)
        {
            return _vehiculoRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
           _vehiculoRepository.Eliminar(id);
        }
        public Vehiculo Guardar(Vehiculo entity)
        {
            return _vehiculoRepository.Guardar(entity);
        }
        public Vehiculo ObtenerPorId(Guid id)
        {
            return _vehiculoRepository.ObtenerPorId(id);
        }
        public IList<Vehiculo> ObtenerTodo()
        {
            return _vehiculoRepository.ObtenerTodo();
        }
    }
}
