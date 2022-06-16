using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarClienteService
    {
        void EliminarCliente(Guid id);
        IList<EmpresaCliente> ObtenerTodoCliente();
        EmpresaCliente ObtenerPorIdCliente(Guid id);
        EmpresaCliente GuardarCliente(EmpresaCliente entity);
        EmpresaCliente ActualizarCliente(EmpresaCliente entity);
        
        IList<ClientesDistribuidora> ObtenerDistribuidorasDeCliente();
        void EliminarDistribuidorasDeCliente(Guid Id);
        ClientesDistribuidora InsertarDistribuidorasDeCliente(ClientesDistribuidora clienteDistribuidora);
    }
}
