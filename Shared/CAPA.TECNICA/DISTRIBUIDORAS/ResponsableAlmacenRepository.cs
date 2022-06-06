using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.DISTRIBUIDORAS
{
    public interface IResponsableAlmacenRepository : IRepository<ResponsableAlmacen>
    {
    }
    public class ResponsableAlmacenRepository : Repository<ResponsableAlmacen>, IResponsableAlmacenRepository
    {
        public ResponsableAlmacenRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
