using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;

namespace CAPAS.CAPA.DOMINIO.PROVEEDORES.ENTIDADES
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
