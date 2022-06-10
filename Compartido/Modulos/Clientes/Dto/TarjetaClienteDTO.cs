using System;

namespace Compartido.Modulos.Clientes.Dto
{
    public class TarjetaClienteDTO
    {
        public Guid Id { get; set; }
        public int NumeroTarjeta { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string NombreTitular { get; set; }
    }
}
