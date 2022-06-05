using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.CLIENTES.ABSTRACCIONES
{
    public interface IAdministrarEmpresaClienteService
    {
        void Eliminar(Guid id);
        IList<EmpresaCliente> ObtenerTodo();
        EmpresaCliente ObtenerPorId(Guid id);
        EmpresaCliente Guardar(EmpresaCliente entity);
        EmpresaCliente Actualizar(EmpresaCliente entity);
    }
}
