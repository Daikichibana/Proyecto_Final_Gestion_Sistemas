using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Dto.Pedidos
{
    public class ConfirmarPedidoDTO
    {
        public Guid Id { get; set; }
        public bool Aceptado { get; set; }
    }
}
