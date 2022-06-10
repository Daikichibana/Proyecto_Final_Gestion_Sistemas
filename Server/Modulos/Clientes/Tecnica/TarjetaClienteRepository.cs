using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Tecnica
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
