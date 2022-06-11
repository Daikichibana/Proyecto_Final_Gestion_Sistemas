using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades
{
    public class OrdenPedido : Entity
    {
        public EmpresaCliente EmpresaCliente { get; set; }
        public bool DeseaFactura { get; set; }
        public bool PedidoConfirmado { get; set; }
        public string AclaracionCliente { get; set; }
        public string AclaracionDistribuidor { get; set; }
        public string MetodoPago { get; set; }
        public byte[] CodigoQR { get; set; }
        
        [ForeignKey("EmpresaCliente")]
        public Guid EmpresaClienteId { get; set; }
        

        public OrdenPedido()
        {

        }

        public OrdenPedido(EmpresaCliente empresaCliente, bool deseaFactura, bool pedidoConfirmado, string aclaracionCliente, string aclaracionDistribuidor, string metodoPago, byte[] codigoQR)
        {
            EmpresaCliente = empresaCliente;
            DeseaFactura = deseaFactura;
            PedidoConfirmado = pedidoConfirmado;
            AclaracionCliente = aclaracionCliente;
            AclaracionDistribuidor = aclaracionDistribuidor;
            MetodoPago = metodoPago;
            CodigoQR = codigoQR;
        }
    }
}