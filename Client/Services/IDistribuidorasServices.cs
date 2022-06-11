using Compartido;
using Compartido.Dto.Distribuidora.General;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Proyecto_Final_Gestion_Sistemas.Client.Services
{
    public interface IDistribuidorasServices
    {

        #region Rubro
        Task<ServiceResponse<List<RubroDTO>>> ObtenerTodoRubro();
        Task<ServiceResponse<RubroDTO>> CrearRubro(RubroDTO Rubro);
        Task<ServiceResponse<RubroDTO>> ActualizarRubro(RubroDTO Rubro);
        Task<ServiceResponse<RubroDTO>> EliminarRubro(RubroDTO Rubro);
        #endregion
    }
}
