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
        Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuario();
        Task<ServiceResponse<UsuarioDTO>> CrearUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<IniciarSesionDTO>> IniciarSesion(UsuarioDTO usuario);

        #endregion

        #region Administrar Rol
        Task<ServiceResponse<List<RolDTO>>> ObtenerTodoRol();
        Task<ServiceResponse<RolDTO>> CrearRol(RolDTO Rol);
        Task<ServiceResponse<RolDTO>> ActualizarRol(RolDTO Rol);
        Task<ServiceResponse<RolDTO>> EliminarRol(RolDTO Rol);
        #endregion

        #region Administrar Conductor
        Task<ServiceResponse<List<ConductorDTO>>> ObtenerTodosLosConductores();
        Task<ServiceResponse<ConductorDTO>> CrearConductor(ConductorDTO conductorDTO);
        Task<ServiceResponse<ConductorDTO>> ActualizarConductor(ConductorDTO conductorDTO);
        Task<ServiceResponse<ConductorDTO>> EliminarConductor(ConductorDTO conductorDTO);
        #endregion

        #region Administrar Responsable Almacen
        #endregion

        #region Administrar Responsble Empresa
        #endregion
    }
}
