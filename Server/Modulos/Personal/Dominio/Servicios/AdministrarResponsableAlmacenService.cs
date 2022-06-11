﻿using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarResponsableAlmacenService : IAdministrarResponsableAlmacenService
    {
        IResponsableAlmacenRepository _responsableAlmacenRepository;
        public AdministrarResponsableAlmacenService(IResponsableAlmacenRepository responsableAlmacenRepository)
        {
            _responsableAlmacenRepository = responsableAlmacenRepository;
        }
        public ResponsableAlmacen Actualizar(ResponsableAlmacen entity)
        {
            return _responsableAlmacenRepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _responsableAlmacenRepository.Eliminar(id);
        }
        public ResponsableAlmacen Guardar(ResponsableAlmacen entity)
        {
            return _responsableAlmacenRepository.Guardar(entity);
        }
        public ResponsableAlmacen ObtenerPorId(Guid id)
        {
            return _responsableAlmacenRepository.ObtenerPorId(id);
        }
        public IList<ResponsableAlmacen> ObtenerTodo()
        {
            return _responsableAlmacenRepository.ObtenerTodo();
        }
    }
}