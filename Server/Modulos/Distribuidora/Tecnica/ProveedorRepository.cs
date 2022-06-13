using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica
{
    public interface IProveedorRepository : IRepository<EmpresaProveedor>
    {
    }
    public class ProveedorRepository : Repository<EmpresaProveedor>, IProveedorRepository
    {
        public ProveedorRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
