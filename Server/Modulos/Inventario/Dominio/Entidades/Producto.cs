using System;
using System.ComponentModel.DataAnnotations.Schema;
using Compartido;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades
{
    public class Producto : Entity
    {
        public EmpresaDistribuidora EmpresaDistribuidora { get; set; }
        public string Nombre { get; set; }
        public TipoProducto TipoProducto { get; set; }
        public string Descripcion { get; set; }

        [ForeignKey("TipoProducto")]
        public Guid TipoProductoId { get; set; }

        [ForeignKey("EmpresaDistribuidora")]
        public Guid EmpresaDistribuidoraId { get; set; }


        public Producto()
        {

        }

        public Producto(EmpresaDistribuidora empresaDisribuidora, string nombre, TipoProducto tipoProducto, string descripcion)
        {
            EmpresaDistribuidora = empresaDisribuidora;
            Nombre = nombre;
            TipoProducto = tipoProducto;
            Descripcion = descripcion;
        }
    }
}
