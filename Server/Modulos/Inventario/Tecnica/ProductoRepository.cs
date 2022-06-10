using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica
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
