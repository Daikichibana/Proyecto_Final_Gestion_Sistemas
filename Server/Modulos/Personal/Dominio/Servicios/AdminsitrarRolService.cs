using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdminsitrarRolService : IAdministrarRolService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidadDeTrabajo;
        public AdminsitrarRolService(IMapper mapper, BaseDatosContext context)
        {
            _mapper = mapper;
            _unidadDeTrabajo = new UnidadDeTrabajo(context);
        }

        public RolDTO ActualizarRol(RolDTO entity)
        {
            var rol = _mapper.Map<Rol>(entity);
            var rolesRegistrados = _unidadDeTrabajo.rolRepository.ObtenerTodo().Where(p => p.Nombre.Equals(rol.Nombre)).ToList();
            if (rolesRegistrados.Count() > 0)
                throw new Exception("Ya existe un rol registrado con ese nombre");

            var rolActualizado = _unidadDeTrabajo.rolRepository.Actualizar(rol);
            _unidadDeTrabajo.Complete();

            return _mapper.Map<RolDTO>(rolActualizado);

        }

        public void EliminarRol(Guid id)
        {
            _unidadDeTrabajo.rolRepository.Eliminar(id);

            _unidadDeTrabajo.Complete();
        }

        public RolDTO GuardarRol(RolDTO entity)
        {
            var rol = _mapper.Map<Rol>(entity);
            var rolesRegistrados = _unidadDeTrabajo.rolRepository.ObtenerTodo().Where(p => p.Nombre.Equals(rol.Nombre)).ToList();
            if (rolesRegistrados.Count() > 0)
                throw new Exception("Ya existe un rol registrado con ese nombre");

            var rolActualizado = _unidadDeTrabajo.rolRepository.Guardar(rol);
            _unidadDeTrabajo.Complete();

            return _mapper.Map<RolDTO>(rolActualizado);
        }

        public RolDTO ObtenerPorIdRol(Guid id)
        {
            var rol = _unidadDeTrabajo.rolRepository.ObtenerPorId(id);

            return _mapper.Map<RolDTO>(rol);
        }

        public IList<RolDTO> ObtenerTodoRol()
        {
            var roles = _unidadDeTrabajo.rolRepository.ObtenerTodo();

            return _mapper.Map<List<RolDTO>>(roles);
        }
    }
}
