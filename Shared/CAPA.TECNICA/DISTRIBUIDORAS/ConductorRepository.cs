using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.DISTRIBUIDORAS
{
    public interface IConductorRepository : IRepository<Conductor>
    {
    }
    public class ConductorRepository : Repository<Conductor>, IConductorRepository
    {
        public ConductorRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
