using System;
using Compartido.Dto.Personal.General;

namespace Compartido.Dto.Distribuidora.General
{
    public class AsignacionVechiculoConductorDTO
    {
        public Guid Id { get; set; }
        public VehiculoDTO Vechiculo { get; set; }
        public ConductorDTO Conductor { get; set; }
        public DateTime FechaAsignacion { get; set; }
        
        public Guid VechiculoId { get; set; }
        public Guid ConductorId { get; set; }
    }
}