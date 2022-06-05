using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using CAPAS.CAPA.TECNICA.USUARIOS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.SERVICIOS
{
    public class AdminsitrarRolService : IAdministrarRolService
    {
        IRolRepository _rolRepository;
        public AdminsitrarRolService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public Rol Actualizar(Rol entity)
        {
            return _rolRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _rolRepository.Eliminar(id);
        }

        public Rol Guardar(Rol entity)
        {
            return _rolRepository.Guardar(entity);
        }

        public Rol ObtenerPorId(Guid id)
        {
            return _rolRepository.ObtenerPorId(id);
        }

        public IList<Rol> ObtenerTodo()
        {
            return _rolRepository.ObtenerTodo();
        }
    }
}
