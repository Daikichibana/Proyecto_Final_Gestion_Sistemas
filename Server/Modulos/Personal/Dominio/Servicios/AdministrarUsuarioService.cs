using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarUsuarioService : IAdministrarUsuarioService
    {
        UnidadDeTrabajo _unidadDeTrabajo;
        IMapper _mapper;
        
        public AdministrarUsuarioService( BaseDatosContext context, IMapper mapper)
        {
            _unidadDeTrabajo = new UnidadDeTrabajo(context);
            _mapper = mapper;
        }

        public UsuarioDTO ActualizarUsuario(UsuarioDTO entity)
        {
            var usuario = _mapper.Map<Usuario>(entity);
            var usuariosExistentes = _unidadDeTrabajo.usuarioRepository.ObtenerTodo().Where(p => p.NombreUsuario.Equals(usuario.NombreUsuario)).ToList();
            if (usuariosExistentes.Count() > 0)
                throw new Exception("Ya existe un usuario registrado con ese nombre");

            var usuarioActualizado = _unidadDeTrabajo.usuarioRepository.Actualizar(usuario);
            _unidadDeTrabajo.usuarioRepository.GuardarCambios();

            return _mapper.Map<UsuarioDTO>(usuarioActualizado);
        }

        public void EliminarUsuario(Guid id)
        {
            _unidadDeTrabajo.usuarioRepository.Eliminar(id);

            _unidadDeTrabajo.usuarioRepository.GuardarCambios();
        }

        public UsuarioDTO GuardarUsuario(UsuarioDTO entity)
        {
            var usuario = _mapper.Map<Usuario>(entity);
            var usuarioExistente = _unidadDeTrabajo.usuarioRepository.ObtenerTodo().Where(p => p.NombreUsuario.Equals(usuario.NombreUsuario)).ToList();
            if (usuarioExistente.Count > 0)
                throw new Exception("Ya existe un usuario con ese nombre");

            _unidadDeTrabajo.usuarioRepository.Guardar(usuario);
            _unidadDeTrabajo.usuarioRepository.GuardarCambios();

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public UsuarioDTO ObtenerPorIdUsuario(Guid id)
        {
            var usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(id);

            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public IList<UsuarioDTO> ObtenerTodoUsuario()
        {
            var usuarios = _unidadDeTrabajo.usuarioRepository.ObtenerTodo();

            return _mapper.Map<IList<UsuarioDTO>>(usuarios);
        }
        public IList<UsuariosRolesDTO> AsignarRolesAUsuario(List<UsuariosRolesDTO> usuarioRoles)
        {
            var roles = _mapper.Map<List<UsuariosRoles>>(usuarioRoles);
            var result = new List<UsuariosRoles>();

            foreach(UsuariosRoles usuarioRole in roles)
            {
                result.Add(_unidadDeTrabajo.usuariosRolesRepository.Guardar(usuarioRole));
            }
            _unidadDeTrabajo.usuariosRolesRepository.GuardarCambios();
            return _mapper.Map<List<UsuariosRolesDTO>>(result);
        }
        public IniciarSesionDTO IniciarSesion(UsuarioDTO usuario)
        {
            bool usuarioValido = false;

            Usuario usuarioTemporal = _unidadDeTrabajo.usuarioRepository.ObtenerTodo().Where(t => t.NombreUsuario.Equals(usuario.NombreUsuario)).FirstOrDefault();

            if (usuarioTemporal != null)
                if (usuarioTemporal.NombreUsuario == usuario.NombreUsuario && usuarioTemporal.Clave == usuario.Clave)
                    usuarioValido = true;
                else
                    usuarioValido = false;

            if (usuarioValido)
            {
                IniciarSesionDTO iniciarSesionDTO = new IniciarSesionDTO();

                var responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerTodo().Where(p => p.UsuarioId.Equals(usuarioTemporal.Id)).FirstOrDefault();
                var RolesDelUsuario = _unidadDeTrabajo.usuariosRolesRepository.ObtenerTodo().Where(p => p.UsuarioId.Equals(usuarioTemporal.Id));
                var RolesConvertidos = new List<UsuariosRolesDTO>();
                foreach (var rol in RolesDelUsuario)
                {
                    var rolConvertido = new UsuariosRolesDTO();
                    rolConvertido.Id = rol.Id;
                    rolConvertido.UsuarioId = rol.UsuarioId;
                    rolConvertido.RolId = rol.RolId;

                    RolesConvertidos.Add(rolConvertido);
                }

                var empresaDistribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerTodo().Where(p => p.ResponsableId.Equals(responsable.Id)).FirstOrDefault();
                var empresaCliente = _unidadDeTrabajo.empresaClienteRepository.ObtenerTodo().Where(p => p.ResponsableId.Equals(responsable.Id)).FirstOrDefault();

                iniciarSesionDTO.NombreUsuario = usuario.NombreUsuario;
                iniciarSesionDTO.Clave = usuario.Clave;

                if (empresaCliente != null)
                {
                    iniciarSesionDTO.IdEmpresa = empresaCliente.Id;
                    iniciarSesionDTO.EsDistribuidora = false;
                    iniciarSesionDTO.Roles = RolesConvertidos;
                    iniciarSesionDTO.NombreEmpresa = empresaCliente.NombreEmpresa;
                }
                else if (empresaDistribuidora != null)
                {
                    iniciarSesionDTO.IdEmpresa = empresaDistribuidora.Id;
                    iniciarSesionDTO.EsDistribuidora = true;
                    iniciarSesionDTO.Roles = RolesConvertidos;
                    iniciarSesionDTO.NombreEmpresa = empresaDistribuidora.NombreEmpresa;
                }

                return iniciarSesionDTO;
            }
            else
            {
                throw new Exception("El usuario o clave no es valido.");
            }
        }

    }
}
