using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica
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
