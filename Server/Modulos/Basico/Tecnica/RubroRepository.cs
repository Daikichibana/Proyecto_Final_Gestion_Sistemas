using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Tecnica
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
