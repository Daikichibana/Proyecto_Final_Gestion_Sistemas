using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica
{
    public interface IFacturaRepository : IRepository<Factura>
    {
    }
    public class FacturaRepository : Repository<Factura>, IFacturaRepository
    {
        public FacturaRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
