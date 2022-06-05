using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.BASICO
{
    public interface IResponsableEmpresaRepository : IRepository<ResponsableEmpresa>
    {
    }
    public class ResponsableEmpresaRepository : Repository<ResponsableEmpresa>, IResponsableEmpresaRepository
    {
        public ResponsableEmpresaRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
