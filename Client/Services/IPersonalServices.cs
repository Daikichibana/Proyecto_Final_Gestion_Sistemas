using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Compartido;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{

    public interface IPersonalServices
    {
        #region Administrar Usuarios
        Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuarios();
        Task<ServiceResponse<UsuarioDTO>> InsertarUsuario(UsuarioDTO usuarioDTO);
        Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO _usuarioDTO);
        Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(Guid Id);
        Task<ServiceResponse<List<UsuariosRolesDTO>>> AsignarRolesAUsuario(List<UsuariosRolesDTO> UsuarioRoles);
        Task<ServiceResponse<IniciarSesionDTO>> IniciarSesion(UsuarioDTO user);

        #endregion

        #region Administrar Rol
        Task<ServiceResponse<List<RolDTO>>> ObtenerTodoRoles();
        Task<ServiceResponse<RolDTO>> InsertarRol(RolDTO _rolDTO);
        Task<ServiceResponse<RolDTO>> ActualizarRol(RolDTO _rolDTO);
        Task<ServiceResponse<RolDTO>> EliminarRol(Guid Id);
        #endregion

        #region Administrar Conductor
        Task<ServiceResponse<List<ConductorDTO>>> ObtenerTodosLosConductores();
        Task<ServiceResponse<List<ConductorDTO>>> CrearConductor(List<ConductorDTO> conductorDTO);
        Task<ServiceResponse<List<ConductorDTO>>> ActualizarConductor(List<ConductorDTO> conductorDTO);
        Task<ServiceResponse<ConductorDTO>> EliminarConductor(Guid id);
        #endregion

        #region Administrar Responsable Almacen
        Task<ServiceResponse<List<ResponsableAlmacenDTO>>> ObtenerTodLosResponsablesDeAlmacen();
        Task<ServiceResponse<List<ResponsableAlmacenDTO>>> InsertarResponsableAlmacen(List<ResponsableAlmacenDTO> responsableAlmacenDTO);
        Task<ServiceResponse<List<ResponsableAlmacenDTO>>> ActualizarResponsableAlmacen(List<ResponsableAlmacenDTO> responsableAlmacenDTO);
        Task<ServiceResponse<ResponsableAlmacenDTO>> EliminarResponsableAlmacen(Guid id);
        #endregion

        #region Administrar Responsble Empresa
        Task<ServiceResponse<List<ResponsableEmpresaDTO>>> ObtenerTodosLosResponsables();
        Task<ServiceResponse<ResponsableEmpresaDTO>> InsertarResponsableEmpresa(ResponsableEmpresaDTO _responsableDTO);
        Task<ServiceResponse<ResponsableEmpresaDTO>> ActualizarResponsableEmpresa(ResponsableEmpresaDTO responsableDTO);
        Task<ServiceResponse<ResponsableEmpresaDTO>> EliminarResponsableEmpresa(Guid id);
        #endregion
    }
}
