using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
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
