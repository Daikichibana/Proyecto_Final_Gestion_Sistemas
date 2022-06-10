using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades
{
    public class TipoProducto : Entity
    {
        public TipoProducto(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }

    }
}
