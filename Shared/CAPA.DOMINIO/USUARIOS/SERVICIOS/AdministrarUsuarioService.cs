﻿using CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using CAPAS.CAPA.TECNICA.USUARIOS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.SERVICIOS
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
    }
}
