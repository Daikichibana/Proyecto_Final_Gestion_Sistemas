using Compartido.Dto.Pedidos.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Dto.Pedidos
{
    public class RegistroPedidoDTO
    {
        public Guid Id { get; set; }
        public bool DeseaFactura { get; set; }
        public bool PedidoConfirmado { get; set; }
        public string AclaracionCliente { get; set; }
        public string AclaracionDistribuidor { get; set; }
        public string MetodoPago { get; set; }
        public byte[] CodigoQR { get; set; }

        public Guid EmpresaClienteId { get; set; }
        public Guid EmpresaDistribuidoraId { get; set; }
        public List<RegistroPedidoDetalleDTO> DetallesOrdenes { get; set; }
    }
}
