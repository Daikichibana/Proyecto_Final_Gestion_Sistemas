using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Dto.Pedidos
{
    public class AsignacionEntregaConductorDTO
    {
        public Guid IdConductorVehiculo { get; set; }
        public Guid IdPedido { get; set; }
    }
}
