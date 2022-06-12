using Compartido.Dto.Personal.General;
using System;
using System.Collections.Generic;

namespace Compartido.Dto.Personal
{
    public class IniciarSesionDTO
    {
        public string NombreUsuario { get; set; }
        public string Clave { get; set; }
        public Guid IdEmpresa { get; set; }
        public List<UsuariosRolesDTO> Roles  { get; set; }
        public bool EsDistribuidora { get; set; }
    }
}
