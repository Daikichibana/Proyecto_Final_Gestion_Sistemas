using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica
{
    public interface IStockRepository : IRepository<Stock>
    {
    }
    public class StockRepository : Repository<Stock>, IStockRepository
    {
        public StockRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
