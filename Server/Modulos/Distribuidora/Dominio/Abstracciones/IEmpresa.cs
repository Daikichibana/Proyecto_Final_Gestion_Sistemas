using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IEmpresa
    {
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public Rubro Rubro { get; set; }
        public NIT NIT { get; set; }
        public ResponsableEmpresa Responsable { get; set; }

        [ForeignKey("Responsable")]
        public Guid ResponsableId { get; set; }
    }
}
