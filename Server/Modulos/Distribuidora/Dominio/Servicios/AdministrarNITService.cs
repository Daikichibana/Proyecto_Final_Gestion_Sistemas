using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarNITService : IAdministrarNITService
    {
        INITRepository _NITrepository;

        public AdministrarNITService (INITRepository nITrepository)
        {
            _NITrepository = nITrepository;
        }
        public NIT ActualizarNIT(NIT entity)
        {
            return _NITrepository.Actualizar(entity);
        }
        public void EliminarNIT(Guid id)
        {
            _NITrepository.Eliminar(id);
        }
        public NIT GuardarNIT(NIT entity)
        {
            return _NITrepository.Guardar(entity);
        }
        public NIT ObtenerPorIdNIT(Guid id)
        {
            return _NITrepository.ObtenerPorId(id);
        }
        public IList<NIT> ObtenerTodoNIT()
        {
            return _NITrepository.ObtenerTodo();
        }
    }
}
