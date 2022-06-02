using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES
{
    public class Producto : Entity
    {
        public string Nombre { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("TipoProducto")]
        public Guid TipoProductoId { get; set; }

        public Producto(string nombre, TipoProducto tipoProducto, string descripcion)
        {
            Nombre = nombre;
            TipoProducto = tipoProducto;
            Descripcion = descripcion;
        }

        public Producto()
        {

        }
    }
}
