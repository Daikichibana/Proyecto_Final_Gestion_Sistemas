using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica
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
