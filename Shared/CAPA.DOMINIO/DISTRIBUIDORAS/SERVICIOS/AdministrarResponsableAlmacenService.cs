﻿using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using CAPAS.CAPA.TECNICA.DISTRIBUIDORAS;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.SERVICIOS
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
