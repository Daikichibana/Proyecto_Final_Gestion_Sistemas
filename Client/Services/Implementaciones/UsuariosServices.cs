using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Compartido;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services.Implementaciones
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly HttpClient _http;
        private string EnlaceRoles = "api/AdministrarRoles";
        private string EnlaceUsuario = "api/AdministrarUsuario";

        public UsuariosServices(HttpClient http)
        {
            _http = http;
        }

        #region Usuario
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

        public async Task<ServiceResponse<UsuarioDTO>> ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            var Enlace = EnlaceUsuario + $"/ObtenerUsuarioPorNombre?nombre={nombreUsuario}";
            var result = await _http.GetFromJsonAsync<ServiceResponse<UsuarioDTO>>(Enlace);

            return result;
        }

        public async Task<ServiceResponse<bool>> ValidarUsuario(ValidarUsuarioDTO usuario)
        {
            var Enlace = EnlaceUsuario + "/ValidarUsuario";
            var result = await _http.PostAsJsonAsync(Enlace, usuario);
            var content = await result.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            
            return content;
        }
        #endregion

        #region Rol

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
    }
}
