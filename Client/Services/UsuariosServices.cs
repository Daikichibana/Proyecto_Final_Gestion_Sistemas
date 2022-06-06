using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.USUARIOS.DTO;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IUsuariosServices
    {
        #region Usuarios
        Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuario();
        Task<ServiceResponse<UsuarioDTO>> ObtenerUsuarioPorNombre(string nombreUsuario);
        Task<ServiceResponse<UsuarioDTO>> CrearUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<bool>> ValidarUsuario(ValidarUsuarioDTO usuario);
        #endregion
    }
    public class UsuariosServices : IUsuariosServices
    {
        private readonly HttpClient _http;
        private string EnlaceRoles = "api/AdministrarRoles";
        private string EnlaceUsuario = "api/AdministrarUsuario";

        public UsuariosServices(HttpClient http)
        {
            _http = http;
        }
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
    }
}
