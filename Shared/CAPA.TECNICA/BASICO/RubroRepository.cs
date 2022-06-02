using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;

namespace CAPAS.CAPA.TECNICA.BASICO
{
    public interface IRubroRepository : IRepository<Rubro>
    {
    }
    public class RubroRepository : Repository<Rubro>, IRubroRepository
    {
        public RubroRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
