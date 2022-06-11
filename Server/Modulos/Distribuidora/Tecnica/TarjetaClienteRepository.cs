using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface ITarjetaClienteRepository : IRepository<TarjetaCliente>
    {
    }
    public class TarjetaClienteRepository : Repository<TarjetaCliente>, ITarjetaClienteRepository
    {
        public TarjetaClienteRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
