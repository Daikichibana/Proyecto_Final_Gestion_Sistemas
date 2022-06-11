using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IEmpresaDistribuidoraRepository : IRepository<EmpresaDistribuidora>
    {

    }
    public class EmpresaDistribuidoraRepository : Repository<EmpresaDistribuidora>, IEmpresaDistribuidoraRepository
    {
        public EmpresaDistribuidoraRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }

}
