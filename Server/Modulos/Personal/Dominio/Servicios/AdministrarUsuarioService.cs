using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarUsuarioService : IAdministrarUsuarioService
    {
        IUsuarioRepository _usuarioRepository;
        public AdministrarUsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Usuario Actualizar(Usuario entity)
        {
            return _usuarioRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _usuarioRepository.Eliminar(id);
        }

        public Usuario Guardar(Usuario entity)
        {
            return _usuarioRepository.Guardar(entity);
        }

        public Usuario ObtenerPorId(Guid id)
        {
            return _usuarioRepository.ObtenerPorId(id);
        }

        public IList<Usuario> ObtenerTodo()
        {
            return _usuarioRepository.ObtenerTodo();
        }

        public bool ValidarUsuario(string nombreUsuario, string clave)
        {
            Usuario usuarioTemporal = _usuarioRepository.ObtenerUsuarioPorNombre(nombreUsuario);

            if (usuarioTemporal != null)
                if (usuarioTemporal.NombreUsuario == nombreUsuario && usuarioTemporal.Clave == clave)
                    return true;

            return false;
        }

        public Usuario ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            return _usuarioRepository.ObtenerUsuarioPorNombre(nombreUsuario);
        }
    }
}
