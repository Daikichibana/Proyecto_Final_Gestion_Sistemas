using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidoras.Tecnica
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
