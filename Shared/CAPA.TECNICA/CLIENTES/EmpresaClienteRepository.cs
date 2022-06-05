using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.CLIENTES
{
    public interface IEmpresaClienteRepository : IRepository<EmpresaCliente>
    {
    }
    public class EmpresaClienteRepository : Repository<EmpresaCliente>, IEmpresaClienteRepository
    {
        public EmpresaClienteRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
