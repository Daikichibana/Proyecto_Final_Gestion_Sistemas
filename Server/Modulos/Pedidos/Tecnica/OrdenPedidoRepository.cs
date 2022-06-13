using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica
{
    public interface IOrdenPedidoRepository : IRepository<OrdenPedido>
    {
    }
    public class OrdenPedidoRepository : Repository<OrdenPedido>, IOrdenPedidoRepository
    {
        public OrdenPedidoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
