namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IIniciarSesionService
    {
        bool ValidarUsuario(string nombre, string clave);
    }
}
