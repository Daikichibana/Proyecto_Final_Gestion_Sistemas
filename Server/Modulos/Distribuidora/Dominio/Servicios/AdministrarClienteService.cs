using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarEmpresaClienteService : IAdministrarClienteService
    {
        IEmpresaClienteRepository _EmpresaClienteRepository;
        IClienteDistribuidoraRepository _ClienteDistribuidoraRepository;
        public AdministrarEmpresaClienteService(IEmpresaClienteRepository EmpresaClienteRepository, IClienteDistribuidoraRepository ClienteDistribuidoraRepository)
        {
            _ClienteDistribuidoraRepository = ClienteDistribuidoraRepository;
            _EmpresaClienteRepository = EmpresaClienteRepository;
        }

        public EmpresaCliente ActualizarCliente(EmpresaCliente entity)
        {
            return _EmpresaClienteRepository.Actualizar(entity);
        }

        public void EliminarCliente(Guid id)
        {
            _EmpresaClienteRepository.Eliminar(id);
        }

        public EmpresaCliente GuardarCliente(EmpresaCliente entity)
        {
            return _EmpresaClienteRepository.Guardar(entity);
        }

        public EmpresaCliente ObtenerPorIdCliente(Guid id)
        {
            return _EmpresaClienteRepository.ObtenerPorId(id);
        }

        public IList<EmpresaCliente> ObtenerTodoCliente()
        {
            return _EmpresaClienteRepository.ObtenerTodo();
        }

        public IList<ClientesDistribuidora> ObtenerDistribuidorasDeCliente()
        {
            return _ClienteDistribuidoraRepository.ObtenerTodo();
        }

        public void EliminarDistribuidorasDeCliente(Guid Id) 
        {
            _ClienteDistribuidoraRepository.Eliminar(Id);
        }
        
        public ClientesDistribuidora InsertarDistribuidorasDeCliente(ClientesDistribuidora clienteDistribuidora)
        {
            return _ClienteDistribuidoraRepository.Guardar(clienteDistribuidora);
        }

    }
}
