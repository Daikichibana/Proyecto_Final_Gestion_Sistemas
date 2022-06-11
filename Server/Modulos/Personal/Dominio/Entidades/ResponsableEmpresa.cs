using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades
{
    public class ResponsableEmpresa : Entity, IPersona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public Usuario Usuario { get; set; }

        [ForeignKey("Usuario")]
        public Guid UsuarioId { get; set; }
     

        public ResponsableEmpresa()
        {

        }

        public ResponsableEmpresa(string nombre, string apellido, string ci, DateTime fechaNacimiento, string email, string telefono, Usuario usuario)
        {
            Nombre = nombre;
            Apellido = apellido;
            Ci = ci;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Telefono = telefono;
            Usuario = usuario;
        }
    }
}
