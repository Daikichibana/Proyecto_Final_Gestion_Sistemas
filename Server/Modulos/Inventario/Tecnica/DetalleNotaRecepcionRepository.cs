using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica
{
    public interface IDetalleNotaRecepcionRepository : IRepository<DetalleNotaRecepcion>
    {
    }
    public class DetalleNotaRecepcionRepository : Repository<DetalleNotaRecepcion>, IDetalleNotaRecepcionRepository
    {
        public DetalleNotaRecepcionRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
