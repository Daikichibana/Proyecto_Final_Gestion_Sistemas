using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class ClientesDistribuidora : Entity
    {
        public EmpresaCliente Clientes { get; set; }
        public EmpresaDistribuidora Distribuidoras { get; set; }

        [ForeignKey("Clientes")]
        public Guid ClientesId { get; set; }

        [ForeignKey("Distribuidoras")]
        public Guid DistribuidorasId{ get; set; }

        public ClientesDistribuidora()
        {

        }

        public ClientesDistribuidora(EmpresaCliente clientes, EmpresaDistribuidora distribuidoras, Guid clientesId, Guid distribuidorasId)
        {
            this.Clientes = clientes;
            this.Distribuidoras = distribuidoras;
            this.ClientesId = clientesId;
            this.DistribuidorasId = distribuidorasId;
        }
    }
}
