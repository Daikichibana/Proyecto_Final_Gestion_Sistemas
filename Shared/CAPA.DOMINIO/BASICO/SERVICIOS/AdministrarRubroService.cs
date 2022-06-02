using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using CAPAS.CAPA.TECNICA;
using CAPAS.CAPA.TECNICA.BASICO;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.BASICO.SERVICIOS
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

        public Rubro ObtenerPorId(int id)
        {
            return _rubroRepository.ObtenerPorId(id);
        }

        public IList<Rubro> ObtenerTodo()
        {
            return _rubroRepository.ObtenerTodo();
        }
    }
}
