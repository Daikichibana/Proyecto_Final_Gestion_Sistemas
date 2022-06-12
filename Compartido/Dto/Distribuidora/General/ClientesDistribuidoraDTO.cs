using System;

namespace Compartido.Dto.Distribuidora.General
{
    public class ClientesDistribuidoraDTO
    {
        public Guid Id { get; set; }
        public EmpresaClienteDTO clientes { get; set; }
        public EmpresaDistribuidoraDTO distribuidoras { get; set; }
        public Guid ClientesId { get; set; }
        public Guid DistribuidorasId { get; set; }
    }
}
