using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Basico.Dominio.Servicios
{
    public class AdministrarRubroService : IAdministrarRubroService
    {
        IRubroRepository _rubroRepository;
        public AdministrarRubroService(IRubroRepository rubroRepository)
        {
            _rubroRepository = rubroRepository;
        }

        public Rubro Actualizar(Rubro entity)
        {
            return _rubroRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _rubroRepository.Eliminar(id);
        }

        public Rubro Guardar(Rubro entity)
        {
            return _rubroRepository.Guardar(entity);
        }

        public Rubro ObtenerPorId(Guid id)
        {
            return _rubroRepository.ObtenerPorId(id);
        }

        public IList<Rubro> ObtenerTodo()
        {
            return _rubroRepository.ObtenerTodo();
        }
    }
}
