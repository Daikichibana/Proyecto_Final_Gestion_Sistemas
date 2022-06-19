using System;
using System.Collections.Generic;
using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarRubroService : IAdministrarRubroService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public AdministrarRubroService(IMapper mapper, BaseDatosContext context)
        {
            _unidad = new UnidadDeTrabajo(context);
            _mapper = mapper;
        }

        public IList<RubroDTO> ActualizarRubro(IList<RubroDTO> entity)
        {
            var listaRubroConvertido = _mapper.Map<List<Rubro>>(entity);
            List<Rubro> result = new List<Rubro>();
            foreach (var rubro in listaRubroConvertido)
            {
                var rubroInsertado = _unidad.rubroRepository.Actualizar(rubro);
                result.Add(rubroInsertado);
            }
            _unidad.Complete();
            return _mapper.Map<List<RubroDTO>>(result);
        }

        public void EliminarRubro(Guid id)
        {
            _unidad.rubroRepository.Eliminar(id);
            _unidad.Complete();
        }

        public IList<RubroDTO> GuardarRubro(IList<RubroDTO> entity)
        {
            var listaRubroConvertido = _mapper.Map<List<Rubro>>(entity);
            List<Rubro> result = new List<Rubro>();
            foreach (var rubro in listaRubroConvertido)
            {
                var rubroInsertado = _unidad.rubroRepository.Guardar(rubro);
                result.Add(rubroInsertado);
            }
            _unidad.Complete();
            return _mapper.Map<List<RubroDTO>>(result);
            
        }

        public RubroDTO ObtenerPorIdRubro(Guid id)
        {
            var rubro = _unidad.rubroRepository.ObtenerPorId(id);

            return _mapper.Map<RubroDTO>(rubro);
        }

        public IList<RubroDTO> ObtenerTodoRubro()
        {
            var listaRubro = _unidad.rubroRepository.ObtenerTodo();
            return _mapper.Map<List<RubroDTO>>(listaRubro);
        }
    }
}
