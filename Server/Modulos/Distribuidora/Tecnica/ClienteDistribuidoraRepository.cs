using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IClienteDistribuidoraRepository : IRepository<ClientesDistribuidora>
    {
    }
    public class ClienteDistribuidoraRepository : Repository<ClientesDistribuidora>, IClienteDistribuidoraRepository
    {
        public ClienteDistribuidoraRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
