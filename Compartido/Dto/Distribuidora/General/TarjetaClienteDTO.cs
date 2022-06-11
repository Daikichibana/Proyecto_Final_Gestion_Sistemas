using System;

namespace Compartido.Dto.Distribuidora.General
{
    public class TarjetaClienteDTO
    {
        public Guid Id { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; }
        public EmpresaClienteDTO EmpresaCliente { get; set; }
        
        public Guid EmpresaClienteId { get; set; }
    }

}
