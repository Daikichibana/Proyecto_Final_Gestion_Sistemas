using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.CLIENTES.DTO
{
    public class TarjetaClienteDTO
    {
        public Guid Id { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; }
    }
}
