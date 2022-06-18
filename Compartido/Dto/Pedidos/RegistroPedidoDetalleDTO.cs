using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Dto.Pedidos
{
    public class RegistroPedidoDetalleDTO
    {
        public Guid Id { get; set; }
        public int CantidadOrdenada { get; set; }
    }
}
