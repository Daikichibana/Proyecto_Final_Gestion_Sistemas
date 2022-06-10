using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica
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
