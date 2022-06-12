using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
{
    public interface IUsuariosRolesRepository : IRepository<UsuariosRoles>
    {
    }
    public class UsuariosRolesRepository : Repository<UsuariosRoles>, IUsuariosRolesRepository
    {
        public UsuariosRolesRepository(BaseDatosContext ctx) : base(ctx)
        {
        }

    }
}
