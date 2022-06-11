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
        #region Usuarios

        Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuario();
        Task<ServiceResponse<UsuarioDTO>> ObtenerUsuarioPorNombre(string nombreUsuario);
        Task<ServiceResponse<UsuarioDTO>> CrearUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<bool>> ValidarUsuario(ValidarUsuarioDTO usuario);

        #endregion
    }
}
