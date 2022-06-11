using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
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
