using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;

namespace CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES
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
