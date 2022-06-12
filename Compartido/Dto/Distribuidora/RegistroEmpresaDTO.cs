using Compartido.Dto.Distribuidora.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.Dto.Distribuidora
{
    public class RegistroEmpresaDTO
    {
        public string NombreEmpresa { get; set; }
        public string RazonSocialEmpresa { get; set; }
        public string EmailEmpresa { get; set; }

        //Rubro
        public RubroDTO Rubro { get; set; }

        //Responsable
        public string NombreResponsable { get; set; }
        public string ApellidoResponsable { get; set; }
        public string CiResponsable { get; set; }
        public DateTime FechaNacimientoResponsable { get; set; }
        public string EmailResponsable { get; set; }
        public string TelefonoResponsable { get; set; }

        //Usuario
        public string NombreUsuario { get; set; }
        public string ClaveUsuario { get; set; }

        // NIT
        public string NombreFacturacion { get; set; }
        public string NumeroNIT { get; set; }
    }
}
