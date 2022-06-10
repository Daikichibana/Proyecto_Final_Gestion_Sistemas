using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Tecnica
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
