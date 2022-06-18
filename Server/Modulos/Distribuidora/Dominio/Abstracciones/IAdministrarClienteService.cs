using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarClienteService
    {
        void EliminarCliente(Guid id);
        IList<EmpresaClienteDTO> ObtenerTodoCliente();
        EmpresaClienteDTO ObtenerPorIdCliente(Guid id);
        EmpresaClienteDTO GuardarCliente(EmpresaClienteDTO entity);
        EmpresaClienteDTO ActualizarCliente(EmpresaClienteDTO entity);
        
        IList<ClientesDistribuidoraDTO> ObtenerDistribuidorasDeCliente(Guid id);
        void EliminarDistribuidorasDeCliente(Guid Id);
        ClientesDistribuidoraDTO InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO clienteDistribuidora);
    }
}
