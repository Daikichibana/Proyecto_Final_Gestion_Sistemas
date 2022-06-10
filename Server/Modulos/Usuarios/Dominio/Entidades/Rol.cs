

using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Entidades
{
    public class Rol : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Rol(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Rol()
        {

        }
    }
}
