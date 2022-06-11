using System;
using Compartido.Dto.Personal.General;

namespace Compartido.Dto.Distribuidora.General
{
    public class VehiculoDTO
    {
        public Guid Id { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public ConductorDTO Conductor { get; set; }
        
        public Guid ConductorId { get; set; }
    }
}
