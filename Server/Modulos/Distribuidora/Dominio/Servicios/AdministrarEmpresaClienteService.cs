using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarEmpresaClienteService : IAdministrarEmpresaClienteService
    {
        IEmpresaClienteRepository _EmpresaClienteRepository;
        public AdministrarEmpresaClienteService(IEmpresaClienteRepository EmpresaClienteRepository)
        {
            _EmpresaClienteRepository = EmpresaClienteRepository;
        }

        public EmpresaCliente Actualizar(EmpresaCliente entity)
        {
            return _EmpresaClienteRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _EmpresaClienteRepository.Eliminar(id);
        }

        public EmpresaCliente Guardar(EmpresaCliente entity)
        {
            return _EmpresaClienteRepository.Guardar(entity);
        }

        public EmpresaCliente ObtenerPorId(Guid id)
        {
            return _EmpresaClienteRepository.ObtenerPorId(id);
        }

        public IList<EmpresaCliente> ObtenerTodo()
        {
            return _EmpresaClienteRepository.ObtenerTodo();
        }
    }
}
