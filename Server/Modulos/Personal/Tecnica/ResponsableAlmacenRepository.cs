using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
{
    public interface IResponsableAlmacenRepository : IRepository<ResponsableAlmacen>
    {
    }
    public class ResponsableAlmacenRepository : Repository<ResponsableAlmacen>, IResponsableAlmacenRepository
    {
        public ResponsableAlmacenRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
