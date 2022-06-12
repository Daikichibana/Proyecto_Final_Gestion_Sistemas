using System;
using System.Collections.Generic;
using Compartido.Dto.Personal;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IAdministrarUsuarioService
    {
        void Eliminar(Guid id);
        IList<Usuario> ObtenerTodo();
        Usuario ObtenerPorId(Guid id);
        Usuario Guardar(Usuario entity);
        Usuario Actualizar(Usuario entity);
        IList<UsuariosRoles> AsignarRolesAUsuario(List<UsuariosRoles> usuarioRoles);
        IniciarSesionDTO IniciarSesion(UsuarioDTO usuario);
    }
}
