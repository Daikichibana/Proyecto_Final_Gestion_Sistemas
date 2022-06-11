using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IEmpresaClienteRepository : IRepository<EmpresaCliente>
    {
    }
    public class EmpresaClienteRepository : Repository<EmpresaCliente>, IEmpresaClienteRepository
    {
        public EmpresaClienteRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
