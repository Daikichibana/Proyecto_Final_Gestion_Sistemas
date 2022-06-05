using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.USUARIOS
{
    public interface IRolRepository : IRepository<Rol>
    {
    }
    public class RolRepository : Repository<Rol>, IRolRepository
    {
        public RolRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
