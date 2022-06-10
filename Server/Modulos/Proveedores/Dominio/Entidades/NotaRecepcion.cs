using System;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;
using Compartido;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Proveedores.Dominio.Entidades
{
    public class NotaRecepcion : Entity
    {
        public DateTime FechaCompra { get; set; }
        public EmpresaProveedor Proveedor { get; set; }
        public EmpresaDistribuidora Distribuidora { get; set; }

        public NotaRecepcion(DateTime fechaCompra, EmpresaProveedor proveedor, EmpresaDistribuidora distribuidora)
        {
            FechaCompra = fechaCompra;
            Proveedor = proveedor;
            Distribuidora = distribuidora;
        }

        public NotaRecepcion()
        {

        }
    }
}
