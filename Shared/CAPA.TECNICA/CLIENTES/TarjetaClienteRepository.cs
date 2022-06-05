using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.CLIENTES
{
    public interface ITarjetaClienteRepository : IRepository<TarjetaCliente>
    {
    }
    public class TarjetaClienteRepository : Repository<TarjetaCliente>, ITarjetaClienteRepository
    {
        public TarjetaClienteRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
