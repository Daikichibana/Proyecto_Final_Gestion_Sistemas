using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS
{
    public class AdministrarConductorService : IAdministrarConductorService
    {
        IConductorRepository _conductorRepository;

        public AdministrarConductorService(IConductorRepository conductorRepository)
        {
            _conductorRepository = conductorRepository;
        }

    }
}
