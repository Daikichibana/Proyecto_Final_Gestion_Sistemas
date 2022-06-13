using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica
{
    public interface IPedidoRepository : IRepository<Pedido>
    {
    }
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        public PedidoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
