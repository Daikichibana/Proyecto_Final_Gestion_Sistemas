namespace CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES
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
