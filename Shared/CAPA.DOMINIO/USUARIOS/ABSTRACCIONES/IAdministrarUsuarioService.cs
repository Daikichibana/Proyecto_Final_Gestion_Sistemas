using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES
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
