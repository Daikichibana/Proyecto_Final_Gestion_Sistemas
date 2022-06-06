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
