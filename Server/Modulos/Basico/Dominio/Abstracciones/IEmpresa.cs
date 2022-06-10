using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Abstracciones
{
    public interface IEmpresa
    {
        public string NombreEmpresa { get; set; }
        public string RazonSocial { get; set; }
        public string EmailEmpresa { get; set; }
        public Rubro Rubro { get; set; }
        public NIT NIT { get; set; }
        public ResponsableEmpresa Responsable { get; set; }
    }
}
