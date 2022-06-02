using System;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES
{
    public interface IPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
