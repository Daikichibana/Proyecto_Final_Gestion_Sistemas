using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using CAPAS.CAPA.TECNICA.USUARIOS;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.SERVICIOS
{
    public class IniciarSesionService : IIniciarSesionService
    {
        IUsuarioRepository _usuarioRepository;

        public IniciarSesionService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            Usuario usuarioTemporal = _usuarioRepository.ObtenerUsuarioPorNombre(nombreUsuario);

            if(usuarioTemporal != null)
                if (usuarioTemporal.NombreUsuario == nombreUsuario && usuarioTemporal.Clave == clave)
                    return true;

            return false;
        }
    }
}
