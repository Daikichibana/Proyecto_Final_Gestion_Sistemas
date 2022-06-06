using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS
{
    public class AdministrarSucursalesService : IAdministrarSucursalesService
    {
        ISucursalRepository _sucursalRepository;
        public AdministrarSucursalesService(ISucursalRepository sucursalRepository)
        {
            _sucursalRepository = sucursalRepository;
        }
        public Sucursales Actualizar(Sucursales entity)
        {
            return _sucursalRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _sucursalRepository.Eliminar(id);
        }
        public Sucursales Guardar(Sucursales entity)
        {
            return _sucursalRepository.Guardar(entity);
        }
        public Sucursales ObtenerPorId(Guid id)
        {
            return _sucursalRepository.ObtenerPorId(id);
        }
        public IList<Sucursales> ObtenerTodo()
        {
            return _sucursalRepository.ObtenerTodo();
        }
    }
}
