using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
{
    public interface IRolRepository : IRepository<Rol>
    {
    }
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
