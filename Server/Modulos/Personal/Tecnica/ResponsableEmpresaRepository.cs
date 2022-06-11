using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
{
    public interface IResponsableEmpresaRepository : Distribuidora.Tecnica.IRepository<ResponsableEmpresa>
    {
    }
    public class ResponsableEmpresaRepository : Distribuidora.Tecnica.Repository<ResponsableEmpresa>, IResponsableEmpresaRepository
    {
        public ResponsableEmpresaRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
