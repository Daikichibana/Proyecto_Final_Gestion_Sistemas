using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.DISTRIBUIDORAS
{
    public interface ISucursalRepository : IRepository<Sucursales>
    {
    }
    public class SucursalRepository : Repository<Sucursales>, ISucursalRepository
    {
        public SucursalRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
