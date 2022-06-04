using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.DISTRIBUIDORAS
{
    public interface IEmpresaDistribuidoraRepository : IRepository<EmpresaDistribuidora>
    {

    }
    public class EmpresaDistribuidoraRepository : Repository<EmpresaDistribuidora>, IEmpresaDistribuidoraRepository
    {
        public EmpresaDistribuidoraRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }

}
