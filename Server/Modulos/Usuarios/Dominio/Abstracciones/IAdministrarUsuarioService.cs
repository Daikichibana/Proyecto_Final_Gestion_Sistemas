using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Usuarios.Dominio.Abstracciones
{
    public interface IAdministrarUsuarioService
    {
        void Eliminar(Guid id);
        IList<Usuario> ObtenerTodo();
        Usuario ObtenerPorId(Guid id);
        Usuario Guardar(Usuario entity);
        Usuario Actualizar(Usuario entity);
        bool ValidarUsuario(string nombreUsuario, string clave);
        Usuario ObtenerUsuarioPorNombre(string nombreUsuario);
    }
}
