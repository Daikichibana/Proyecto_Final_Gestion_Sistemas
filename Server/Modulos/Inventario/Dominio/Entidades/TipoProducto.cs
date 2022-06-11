using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades
{
    public class TipoProducto : Entity
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public TipoProducto()
        {

        }

        public TipoProducto(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}
