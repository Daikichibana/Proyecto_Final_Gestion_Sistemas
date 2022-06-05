using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.DTO
{
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public RolDTO Rol { get; set; }
        public Guid RolId { get; set; }
    }
}
