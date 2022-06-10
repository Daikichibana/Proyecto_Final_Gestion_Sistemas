using System;
using System.ComponentModel.DataAnnotations.Schema;
using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades
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
