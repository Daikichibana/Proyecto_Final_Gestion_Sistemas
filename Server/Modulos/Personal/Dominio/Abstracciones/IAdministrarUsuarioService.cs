using System;
using System.Collections.Generic;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarUsuarioService
    {
        void EliminarUsuario(Guid id);
        IList<UsuarioDTO> ObtenerTodoUsuario();
        UsuarioDTO ObtenerPorIdUsuario(Guid id);
        UsuarioDTO GuardarUsuario(UsuarioDTO entity);
        UsuarioDTO ActualizarUsuario(UsuarioDTO entity);
        IList<UsuariosRolesDTO> AsignarRolesAUsuario(List<UsuariosRolesDTO> usuarioRoles);
        IniciarSesionDTO IniciarSesion(UsuarioDTO usuario);
    }
}
