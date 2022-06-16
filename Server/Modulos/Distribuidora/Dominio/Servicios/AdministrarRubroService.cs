using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarRubroService : IAdministrarRubroService
    {
        IRubroRepository _rubroRepository;
        public AdministrarRubroService(IRubroRepository rubroRepository)
        {
            _rubroRepository = rubroRepository;
        }

        public Rubro ActualizarRubro(Rubro entity)
        {
            return _rubroRepository.Actualizar(entity);
        }

        public void EliminarRubro(Guid id)
        {
            _rubroRepository.Eliminar(id);
        }

        public Rubro GuardarRubro(Rubro entity)
        {
            return _rubroRepository.Guardar(entity);
        }

        public Rubro ObtenerPorIdRubro(Guid id)
        {
            return _rubroRepository.ObtenerPorId(id);
        }

        public IList<Rubro> ObtenerTodoRubro()
        {
            return _rubroRepository.ObtenerTodo();
        }
    }
}
