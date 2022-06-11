using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IRubroRepository : IRepository<Rubro>
    {
    }
    public class RubroRepository : Repository<Rubro>, IRubroRepository
    {
        public RubroRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
