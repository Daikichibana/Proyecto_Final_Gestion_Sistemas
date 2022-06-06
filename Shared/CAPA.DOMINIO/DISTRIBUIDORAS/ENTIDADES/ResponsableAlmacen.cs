using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES
{
    public class ResponsableAlmacen : Entity, IPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        /*public EmpresaDistribuidora Distribuidora { get; set; }

        [ForeignKey("EmpresaDistribuidora")]
        public Guid DistribuidoraId { get; set; }*/

        public ResponsableAlmacen(string nombre, string apellido, string ci, DateTime fechaNacimiento, string email, string telefono)//, EmpresaDistribuidora empresaDistribuidora)
        {
            Nombre = nombre;
            Apellido = apellido;
            Ci = ci;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
            //Distribuidora = empresaDistribuidora;
        }

        public ResponsableAlmacen()
        {

        }
    }
}
