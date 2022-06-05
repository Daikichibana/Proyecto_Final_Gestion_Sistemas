using CAPAS.CAPA.DOMINIO.CLIENTES.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using CAPAS.CAPA.TECNICA.CLIENTES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.CLIENTES.SERVICIOS
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
