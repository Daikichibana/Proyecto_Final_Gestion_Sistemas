using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Tecnica
{
    public interface IResponsableEmpresaRepository : IRepository<ResponsableEmpresa>
    {
    }
    public class ResponsableEmpresaRepository : Repository<ResponsableEmpresa>, IResponsableEmpresaRepository
    {
        public ResponsableEmpresaRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
