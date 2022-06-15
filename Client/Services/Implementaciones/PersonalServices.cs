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
        private string EnlaceRoles = "api/AdministrarRoles";
        private string EnlaceUsuario = "api/AdministrarUsuario";
        private string EnlaceConductor = "api/AdministrarConductor";

        public PersonalServices(HttpClient http)
        {
            _http = http;
        }

        #region Administrar Usuario
        public async Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO usuario)
        {
            var Enlace = EnlaceUsuario + "/ActualizarUsuario";
            var result = await _http.PutAsJsonAsync(Enlace, usuario);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UsuarioDTO>>();

            return content;
        }

        public async Task<ServiceResponse<UsuarioDTO>> CrearUsuario(UsuarioDTO usuario)
        {
            var Enlace = EnlaceUsuario + "/InsertarUsuario";
            var result = await _http.PostAsJsonAsync(Enlace, usuario);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UsuarioDTO>>();

            return content;
        }

        public async Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(UsuarioDTO usuario)
        {
            var Enlace = $"{EnlaceUsuario}/EliminarUsuario?Id={usuario.Id}";
            var result = await _http.DeleteAsync(Enlace);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<UsuarioDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuario()
        {
            var Enlace = EnlaceUsuario + "/ObtenerTodoUsuarios";
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<UsuarioDTO>>>(Enlace);
            return result;
        }

        public async Task<ServiceResponse<IniciarSesionDTO>> IniciarSesion(UsuarioDTO usuario)
        {
            var Enlace = EnlaceUsuario + "/IniciarSesion";
            var result = await _http.PostAsJsonAsync(Enlace, usuario);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<IniciarSesionDTO>>();

            return content;
        }
        #endregion

        #region Administrar Rol

        public async Task<ServiceResponse<RolDTO>> ActualizarRol(RolDTO Rol)
        {
            var result = await _http.PutAsJsonAsync(EnlaceRoles, Rol);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RolDTO>>();

            return content;
        }

        public async Task<ServiceResponse<RolDTO>> CrearRol(RolDTO Rol)
        {
            var result = await _http.PostAsJsonAsync(EnlaceRoles, Rol);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RolDTO>>();

            return content;
        }

        public async Task<ServiceResponse<RolDTO>> EliminarRol(RolDTO Rol)
        {
            var result = await _http.DeleteAsync($"{EnlaceRoles}/?Id={Rol.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<RolDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<RolDTO>>> ObtenerTodoRol()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<RolDTO>>>(EnlaceRoles);
            return result;
        }
        #endregion

        #region Administrar Conductor
        public async Task<ServiceResponse<ConductorDTO>> ActualizarConductor(ConductorDTO conductor)
        {
            var result = await _http.PutAsJsonAsync(EnlaceConductor, conductor);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ConductorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<ConductorDTO>> CrearConductor(ConductorDTO conductor)
        {
            var result = await _http.PostAsJsonAsync(EnlaceConductor, conductor);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ConductorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<ConductorDTO>> EliminarConductor(ConductorDTO conductor)
        {
            var result = await _http.DeleteAsync($"{EnlaceConductor}?Id={conductor.Id}");
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<ConductorDTO>>();

            return content;
        }

        public async Task<ServiceResponse<List<ConductorDTO>>> ObtenerTodosLosConductores()
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<ConductorDTO>>>(EnlaceConductor);
            return result;
        }

        #endregion

        #region Administrar responsable almacen
        #endregion

        #region Administrar responsable Empresa
        #endregion
    }
}
