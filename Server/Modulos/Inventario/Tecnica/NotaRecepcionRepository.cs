using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica
{
    public interface INotaRecepcionRepository : IRepository<NotaRecepcion>
    {
    }
    public class NotaRecepcionRepository : Repository<NotaRecepcion>, INotaRecepcionRepository
    {
        public NotaRecepcionRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
