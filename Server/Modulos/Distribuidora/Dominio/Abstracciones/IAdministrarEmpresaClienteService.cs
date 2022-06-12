using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarEmpresaClienteService
    {
        void Eliminar(Guid id);
        IList<EmpresaCliente> ObtenerTodo();
        EmpresaCliente ObtenerPorId(Guid id);
        EmpresaCliente Guardar(EmpresaCliente entity);
        EmpresaCliente Actualizar(EmpresaCliente entity);
        
        IList<ClientesDistribuidora> ObtenerDistribuidorasDeCliente();
        void EliminarDistribuidorasDeCliente(Guid Id);
        ClientesDistribuidora InsertarDistribuidorasDeCliente(ClientesDistribuidora clienteDistribuidora);
    }
}
