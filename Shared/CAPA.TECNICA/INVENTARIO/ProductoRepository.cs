using CAPAS.CAPA.DOMINIO.INVENTARIO.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.INVENTARIO
{
    public interface IProductoRepository : IRepository<Producto>
    {
    }
    public class ProductoRepository : Repository<Producto>, IProductoRepository
    {
        public ProductoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
