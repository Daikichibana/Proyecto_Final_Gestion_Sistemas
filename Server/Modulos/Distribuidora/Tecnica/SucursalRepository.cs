using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface ISucursalRepository : IRepository<Sucursales>
    {
    }
    public class SucursalRepository : Repository<Sucursales>, ISucursalRepository
    {
        public SucursalRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
