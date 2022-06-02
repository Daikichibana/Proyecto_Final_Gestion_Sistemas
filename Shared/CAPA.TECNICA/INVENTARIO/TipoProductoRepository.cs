using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;

namespace CAPAS.CAPA.TECNICA.INVENTARIO
{
    public interface ITipoProductoRepository : IRepository<TipoProducto>
    { 
    }
    public class TipoProductoRepository : Repository<TipoProducto>, ITipoProductoRepository
    {
        public TipoProductoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
