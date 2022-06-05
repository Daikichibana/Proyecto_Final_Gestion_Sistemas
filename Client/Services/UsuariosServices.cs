using CAPAS.CAPA.DOMINIO;
using CAPAS.CAPA.DOMINIO.USUARIOS.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IUsuariosServices
    {
        Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuario();
        Task<ServiceResponse<UsuarioDTO>> CrearUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO usuario);
        Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(UsuarioDTO usuario);
        ServiceResponse<bool> ValidarUsuario(UsuarioDTO usuario);
    }
    public class UsuariosServices : IUsuariosServices
    {
        public Task<ServiceResponse<UsuarioDTO>> ActualizarUsuario(UsuarioDTO usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<UsuarioDTO>> CrearUsuario(UsuarioDTO usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<UsuarioDTO>> EliminarUsuario(UsuarioDTO usuario)
        {
            throw new System.NotImplementedException();
        }

        public Task<ServiceResponse<List<UsuarioDTO>>> ObtenerTodoUsuario()
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<bool> ValidarUsuario(UsuarioDTO usuario)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();

            if (usuario.NombreUsuario == "daiki" && usuario.Clave == "Password")
            {
                response.Data = true;

            }
            else
            {
                response.Data = false;
            }
            response.Success = true;
            response.Message = "";

            return response;
        }
    }
}
