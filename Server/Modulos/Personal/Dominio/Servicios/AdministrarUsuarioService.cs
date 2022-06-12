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

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarUsuarioService : IAdministrarUsuarioService
    {
        IUsuarioRepository _usuarioRepository;
        IResponsableEmpresaRepository _responsableEmpresaRepository;
        IEmpresaDistribuidoraRepository _empresaDistribuidoraRepository;
        IEmpresaClienteRepository _empresaClienteRepository;
        IUsuariosRolesRepository _usuariosRolesRepository;
        
        public AdministrarUsuarioService( IUsuarioRepository usuarioRepository, IUsuariosRolesRepository usuariosRolesRepository,IResponsableEmpresaRepository responsableEmpresaRepository, IEmpresaClienteRepository clienteRepository, IEmpresaDistribuidoraRepository distribuidoraRepository)
        {
            _usuariosRolesRepository = usuariosRolesRepository;
            _responsableEmpresaRepository = responsableEmpresaRepository;
            _empresaDistribuidoraRepository = distribuidoraRepository;
            _empresaClienteRepository = clienteRepository;
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Actualizar(Usuario entity)
        {
            return _usuarioRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _usuarioRepository.Eliminar(id);
        }

        public Usuario Guardar(Usuario entity)
        {
            return _usuarioRepository.Guardar(entity);
        }

        public Usuario ObtenerPorId(Guid id)
        {
            return _usuarioRepository.ObtenerPorId(id);
        }

        public IList<Usuario> ObtenerTodo()
        {
            return _usuarioRepository.ObtenerTodo();
        }
        public IList<UsuariosRoles> AsignarRolesAUsuario(List<UsuariosRoles> usuarioRoles)
        {
            List<UsuariosRoles> result = new List<UsuariosRoles>();

            foreach(UsuariosRoles usuarioRole in usuarioRoles)
            {
                result.Add(_usuariosRolesRepository.Guardar(usuarioRole));
            }

            return result;
        }
        public IniciarSesionDTO IniciarSesion(UsuarioDTO usuario)
        {
            bool usuarioValido = false;

            Usuario usuarioTemporal = _usuarioRepository.ObtenerTodo().Where(t => t.NombreUsuario.Equals(usuario.NombreUsuario)).FirstOrDefault();

            if (usuarioTemporal != null)
                if (usuarioTemporal.NombreUsuario == usuario.NombreUsuario && usuarioTemporal.Clave == usuario.Clave)
                    usuarioValido = true;
                else
                    usuarioValido = false;

            if (usuarioValido)
            {
                IniciarSesionDTO iniciarSesionDTO = new IniciarSesionDTO();

                var responsable = _responsableEmpresaRepository.ObtenerTodo().Where(p => p.UsuarioId.Equals(usuarioTemporal.Id)).FirstOrDefault();
                var RolesDelUsuario = _usuariosRolesRepository.ObtenerTodo().Where(p => p.UsuarioId.Equals(usuarioTemporal.Id));
                var RolesConvertidos = new List<UsuariosRolesDTO>();
                foreach (var rol in RolesDelUsuario)
                {
                    var rolConvertido = new UsuariosRolesDTO();
                    rolConvertido.Id = rol.Id;
                    rolConvertido.UsuarioId = rol.UsuarioId;
                    rolConvertido.RolId = rol.RolId;

                    RolesConvertidos.Add(rolConvertido);
                }

                var empresaDistribuidora = _empresaDistribuidoraRepository.ObtenerTodo().Where(p => p.ResponsableId.Equals(responsable.Id)).FirstOrDefault();
                var empresaCliente = _empresaClienteRepository.ObtenerTodo().Where(p => p.ResponsableId.Equals(responsable.Id)).FirstOrDefault();

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
