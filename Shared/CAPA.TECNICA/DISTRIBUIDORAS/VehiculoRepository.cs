using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.TECNICA.DISTRIBUIDORAS
{
    public interface IVehiculoRepository : IRepository<Vehiculo>
    {
    }
    public class VehiculoRepository : Repository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository(BaseDatosContext ctx) : base(ctx)
        {
        }
    }
}
