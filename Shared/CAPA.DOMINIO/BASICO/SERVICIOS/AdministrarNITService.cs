﻿using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.TECNICA.BASICO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.BASICO.SERVICIOS
{
    public class AdministrarNITService : INITService
    {
        INITRepository _NITrepository;

        public AdministrarNITService (INITRepository nITrepository)
        {
            _NITrepository = nITrepository;
        }
        public NIT Actualizar(NIT entity)
        {
            return _NITrepository.Actualizar(entity);
        }
        public void Eliminar(Guid id)
        {
            _NITrepository.Eliminar(id);
        }
        public NIT Guardar(NIT entity)
        {
            return _NITrepository.Guardar(entity);
        }
        public NIT ObtenerPorId(Guid id)
        {
            return _NITrepository.ObtenerPorId(id);
        }

        public IList<NIT> ObtenerTodo()
        {
            return _NITrepository.ObtenerTodo();
        }
    }
}
