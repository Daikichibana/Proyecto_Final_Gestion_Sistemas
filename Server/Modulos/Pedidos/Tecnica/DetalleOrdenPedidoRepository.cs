using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica
{
    public interface IDetalleOrdenPedidoRepository : IRepository<DetalleOrdenPedido>
    {
    }
    public class DetalleOrdenPedidoRepository : Repository<DetalleOrdenPedido>, IDetalleOrdenPedidoRepository
    {
        public DetalleOrdenPedidoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
