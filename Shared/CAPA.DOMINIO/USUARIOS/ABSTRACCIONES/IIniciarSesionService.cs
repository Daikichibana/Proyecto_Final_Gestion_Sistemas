using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES
{
    public interface IIniciarSesionService
    {
        bool ValidarUsuario(string nombre, string clave);
    }
}
