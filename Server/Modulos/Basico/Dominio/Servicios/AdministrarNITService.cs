using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Servicios
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
