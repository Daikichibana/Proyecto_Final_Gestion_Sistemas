using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica
{
    public interface IConductorRepository : IRepository<Conductor>
    {
    }
    public class ConductorRepository : Repository<Conductor>, IConductorRepository
    {
        public ConductorRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
