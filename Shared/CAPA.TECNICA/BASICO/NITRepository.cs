using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.BASICO
{
    public interface INITRepository : IRepository<NIT>
    {
    }
    public class NITRepository : Repository<NIT>, INITRepository
    {
        public NITRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
