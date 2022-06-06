using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.DTO
{
    public class VehiculoDTO
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
    }
}
