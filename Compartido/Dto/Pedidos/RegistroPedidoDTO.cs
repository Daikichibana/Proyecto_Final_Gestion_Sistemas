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
        public OrdenPedidoDTO Orden { get; set; }
        public List<DetalleOrdenPedidoDTO> ProductoCarrito { get; set; }
    }
}
