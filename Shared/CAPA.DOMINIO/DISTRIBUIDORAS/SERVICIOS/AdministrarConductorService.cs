using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS
{
    public class AdministrarConductorService : IAdministrarConductorService
    {
        IConductorRepository _conductorRepository;

        public AdministrarConductorService(IConductorRepository conductorRepository)
        {
            _conductorRepository = conductorRepository;
        }
        public Conductor Actualizar(Conductor entity)
        {
            return _conductorRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _conductorRepository.Eliminar(id);
        }
        public Conductor Guardar(Conductor entity)
        {
            return _conductorRepository.Guardar(entity);
        }
        public Conductor ObtenerPorId(Guid id)
        {
            return _conductorRepository.ObtenerPorId(id);
        }
        public IList<Conductor> ObtenerTodo()
        {
            return _conductorRepository.ObtenerTodo();
        }

    }
}
