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
        public List<Stock> Stock { get; set; }
        public bool DeseaFactura { get; set; }
        public bool PedidoConfirmado { get; set; }
        public string AclaracionCliente { get; set; }
        public string AclaracionDistribuidor { get; set; }
        public string MetodoPago { get; set; }
        public byte[] CodigoQR { get; set; }
        
        [ForeignKey("EmpresaCliente")]
        public Guid EmpresaClienteId { get; set; }
        
        [ForeignKey("EmpresaDistribuidora")]
        public Guid EmpresaDistribuidoraId { get; set; }

        public OrdenPedido()
        {

        }

        public OrdenPedido(EmpresaCliente empresaCliente, List<Stock> stock, bool deseaFactura, bool pedidoConfirmado, string aclaracionCliente, string aclaracionDistribuidor, string metodoPago, byte[] codigoQR, Guid empresaClienteId, Guid empresaDistribuidoraId)
        {
            EmpresaCliente = empresaCliente;
            Stock = stock;
            DeseaFactura = deseaFactura;
            PedidoConfirmado = pedidoConfirmado;
            AclaracionCliente = aclaracionCliente;
            AclaracionDistribuidor = aclaracionDistribuidor;
            MetodoPago = metodoPago;
            CodigoQR = codigoQR;
            EmpresaClienteId = empresaClienteId;
            EmpresaDistribuidoraId = empresaDistribuidoraId;
        }

    }
}