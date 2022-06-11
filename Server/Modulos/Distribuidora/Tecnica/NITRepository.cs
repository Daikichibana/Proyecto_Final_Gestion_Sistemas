using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface INITRepository : IRepository<NIT>
    {
    }
    public class NITRepository : Repository<NIT>, INITRepository
    {
        public NITRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
