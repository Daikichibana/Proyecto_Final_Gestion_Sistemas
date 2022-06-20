using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Compartido;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services.Implementaciones
{
    public class PersonalServices : IPersonalServices
    {
        private readonly HttpClient _http;
        private string BaseRoles = "api/AdministrarRoles";
        private string BaseUsuario = "api/AdministrarUsuario";
        private string BaseConductor = "api/AdministrarConductor";
        private string BaseResponsableEmpresa = "api/AdministrarResponsableEmpresa";
        private string BaseResponsableAlmacen = "api/AdministrarResponsableAlmacen";

        public PersonalServices(HttpClient http)
        {
            _http = http;
        }
        #region Administrar Usuarios
        public async Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuarios() 
        {
            string EnlaceUsuario = BaseUsuario + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<UsuarioDTO>>>(EnlaceUsuario);
            return result;
        }

        public async Task<ServiceResponse<UsuarioDTO>> InsertarUsuario(UsuarioDTO usuarioDTO)
        {
            string EnlaceUsuario = BaseUsuario + "/";
            var result = await _http.PostAsJsonAsync(EnlaceUsuario, usuarioDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UsuarioDTO>>();

            return content;
        }
        public async Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO _usuarioDTO)
        {
            string EnlaceUsuario = BaseUsuario + "/";
            var result = await _http.PutAsJsonAsync(EnlaceUsuario, _usuarioDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UsuarioDTO>>();

            return content;
        }
        public async Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(Guid Id)
        {
            string EnlaceUsuario = BaseUsuario + "/";
            var result = await _http.DeleteAsync(EnlaceUsuario);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UsuarioDTO>>();

            return content;
        }
        public async Task<ServiceResponse<List<UsuariosRolesDTO>>> AsignarRolesAUsuario(List<UsuariosRolesDTO> UsuarioRoles)
        {
            string EnlaceUsuario = BaseUsuario + "/";
            var result = await _http.PostAsJsonAsync(EnlaceUsuario, UsuarioRoles);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<UsuariosRolesDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<IniciarSesionDTO>> IniciarSesion(UsuarioDTO user)
        {
            string EnlaceUsuario = BaseUsuario + "/IniciarSesion";
            var result = await _http.PostAsJsonAsync(EnlaceUsuario, user);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<IniciarSesionDTO>>();

            return content;
        }

        #endregion

        #region Administrar Rol
        public async Task<ServiceResponse<List<RolDTO>>> ObtenerTodoRoles()
        {
            string EnlaceRol = BaseRoles + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<RolDTO>>>(EnlaceRol);
            return result;
        }
        public async Task<ServiceResponse<RolDTO>> InsertarRol(RolDTO _rolDTO)
        {
            string EnlaceRol = BaseRoles + "/";
            var result = await _http.PostAsJsonAsync(EnlaceRol, _rolDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RolDTO>>();

            return content;
        }
        public async Task<ServiceResponse<RolDTO>> ActualizarRol(RolDTO _rolDTO)
        {
            string EnlaceRol = BaseRoles + "/";
            var result = await _http.PutAsJsonAsync(EnlaceRol, _rolDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RolDTO>>();

            return content;
        }
        public async Task<ServiceResponse<RolDTO>> EliminarRol(Guid Id)
        {
            string EnlaceRol = BaseRoles + "/";
            var result = await _http.DeleteAsync(EnlaceRol);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RolDTO>>();

            return content;
        }
        #endregion

        #region Administrar Conductor
        public async Task<ServiceResponse<List<ConductorDTO>>> ObtenerTodosLosConductores()
        {
            string EnlaceConductor = BaseConductor + "/ObtenerTodosLosConductores";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ConductorDTO>>>(EnlaceConductor);
            return result;
        }
        public async Task<ServiceResponse<List<ConductorDTO>>> CrearConductor(List<ConductorDTO> conductorDTO)
        {
            string EnlaceConductor = BaseConductor + "/CrearConductor";
            var result = await _http.PostAsJsonAsync(EnlaceConductor, conductorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ConductorDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<ConductorDTO>>> ActualizarConductor(List<ConductorDTO> conductorDTO)
        {
            string EnlaceConductor = BaseConductor + "/ActualizarConductor";
            var result = await _http.PutAsJsonAsync(EnlaceConductor, conductorDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ConductorDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<ConductorDTO>> EliminarConductor(Guid id)
        {
            string EnlaceConductor = BaseConductor + $"/EliminarConductor?id={id}";
            var result = await _http.DeleteAsync(EnlaceConductor);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ConductorDTO>>();

            return content;
        }
        #endregion

        #region Administrar Responsable Almacen
        public async Task<ServiceResponse<List<ResponsableAlmacenDTO>>> ObtenerTodLosResponsablesDeAlmacen()
        {
            string EnlaceResponsableAlmacen = BaseResponsableAlmacen + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ResponsableAlmacenDTO>>>(EnlaceResponsableAlmacen);
            return result;
        }
        public async Task<ServiceResponse<List<ResponsableAlmacenDTO>>> InsertarResponsableAlmacen(List<ResponsableAlmacenDTO> responsableAlmacenDTO)
        {
            string EnlaceResponsableAlmacen = BaseResponsableAlmacen + "/";
            var result = await _http.PostAsJsonAsync(EnlaceResponsableAlmacen, responsableAlmacenDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ResponsableAlmacenDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<List<ResponsableAlmacenDTO>>> ActualizarResponsableAlmacen(List<ResponsableAlmacenDTO> responsableAlmacenDTO)
        {
            string EnlaceResponsableAlmacen = BaseResponsableAlmacen + "/";
            var result = await _http.PutAsJsonAsync(EnlaceResponsableAlmacen, responsableAlmacenDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<List<ResponsableAlmacenDTO>>>();

            return content;
        }
        public async Task<ServiceResponse<ResponsableAlmacenDTO>> EliminarResponsableAlmacen(Guid id)
        {
            string EnlaceResponsableAlmacen = BaseResponsableAlmacen + "/";
            var result = await _http.DeleteAsync(EnlaceResponsableAlmacen);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ResponsableAlmacenDTO>>();

            return content;
        }
        #endregion

        #region Administrar Responsble Empresa
        public async Task<ServiceResponse<List<ResponsableEmpresaDTO>>> ObtenerTodosLosResponsables()
        {
            string EnlaceResponsableEmpresa = BaseResponsableEmpresa + "/";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ResponsableEmpresaDTO>>>(EnlaceResponsableEmpresa);
            return result;
        }
        public async Task<ServiceResponse<ResponsableEmpresaDTO>> InsertarResponsableEmpresa(ResponsableEmpresaDTO _responsableDTO)
        {
            string EnlaceResponsableEmpresa = BaseResponsableEmpresa + "/";
            var result = await _http.PostAsJsonAsync(EnlaceResponsableEmpresa, _responsableDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ResponsableEmpresaDTO>>();

            return content;
        }
        public async Task<ServiceResponse<ResponsableEmpresaDTO>> ActualizarResponsableEmpresa(ResponsableEmpresaDTO responsableDTO)
        {
            string EnlaceResponsableEmpresa = BaseResponsableEmpresa + "/";
            var result = await _http.PutAsJsonAsync(EnlaceResponsableEmpresa, responsableDTO);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ResponsableEmpresaDTO>>();

            return content;
        }
        public async Task<ServiceResponse<ResponsableEmpresaDTO>> EliminarResponsableEmpresa(Guid id)
        {
            string EnlaceResponsableEmpresa = BaseResponsableEmpresa + "/";
            var result = await _http.DeleteAsync(EnlaceResponsableEmpresa);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ResponsableEmpresaDTO>>();

            return content;
        }
        #endregion
    }
}
