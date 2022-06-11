using System;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades
{
    public class AsignacionVechiculoConductor : Entity
    {
        public Vechiculo Vechiculo { get; set; }
        public Conductor Conductor { get; set; }
        public DateTime FechaAsignacion { get; set; }
        
        [ForeignKey("Vechiculo")]
        public Guid VechiculoId { get; set; }
        
        [ForeignKey("Conductor")]
        public Guid ConductorId { get; set; }

        public AsignacionVechiculoConductor()
        {

        }

        public AsignacionVechiculoConductor(Vechiculo vechiculo, Conductor conductor, DateTime fechaAsignacion, Guid vechiculoId, Guid conductorId)
        {
            Vechiculo = vechiculo;
            Conductor = conductor;
            FechaAsignacion = fechaAsignacion;
            VechiculoId = vechiculoId;
            ConductorId = conductorId;
        }
    }
}