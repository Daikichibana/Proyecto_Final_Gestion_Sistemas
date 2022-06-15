using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IAsignacionVechiculoConductorRepository : IRepository<AsignacionVechiculoConductor>
    {
    }
    public class AsignacionVechiculoConductorRepository : Repository<AsignacionVechiculoConductor>, IAsignacionVechiculoConductorRepository
    {
        public AsignacionVechiculoConductorRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
