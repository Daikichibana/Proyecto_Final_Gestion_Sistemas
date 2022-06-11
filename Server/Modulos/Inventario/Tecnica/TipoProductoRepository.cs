using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica
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
