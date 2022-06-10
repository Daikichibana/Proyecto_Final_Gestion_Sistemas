using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Tecnica
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
