using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IVehiculoRepository : IRepository<Vechiculo>
    {
    }
    public class VehiculoRepository : Repository<Vechiculo>, IVehiculoRepository
    {
        public VehiculoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
