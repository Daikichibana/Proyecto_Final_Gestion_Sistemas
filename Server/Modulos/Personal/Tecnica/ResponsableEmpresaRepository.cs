using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
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
