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
    public class AdministrarNITService : IAdministrarNITService
    {
        UnidadDeTrabajo _unidadDeTrabajo;
        IMapper _mapper;

        public AdministrarNITService (IMapper mapper, UnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _mapper = mapper;
        }
        public NITDTO ActualizarNIT(NITDTO entity)
        {
            var nit = _mapper.Map<NIT>(entity);
            var nitActualizado = _unidadDeTrabajo.nitRepository.Actualizar(nit);

            _unidadDeTrabajo.nitRepository.GuardarCambios();
            return _mapper.Map<NITDTO>(nitActualizado);
        }
        public void EliminarNIT(Guid id)
        {
            _unidadDeTrabajo.nitRepository.Eliminar(id);
            _unidadDeTrabajo.nitRepository.GuardarCambios();
        }
        public NITDTO GuardarNIT(NITDTO entity)
        {
            var nit = _mapper.Map<NIT>(entity);
            _unidadDeTrabajo.nitRepository.Guardar(nit);

            _unidadDeTrabajo.nitRepository.GuardarCambios();
            return _mapper.Map<NITDTO>(nit);
        }
        public NITDTO ObtenerPorIdNIT(Guid id)
        {
            var nit = _mapper.Map<NIT>(_unidadDeTrabajo.nitRepository.ObtenerPorId(id));
            return _mapper.Map<NITDTO>(nit);
        }
        public IList<NITDTO> ObtenerTodoNIT()
        {
            var nit = _unidadDeTrabajo.nitRepository.ObtenerTodo();
            return _mapper.Map<IList<NITDTO>>(nit);
        }
    }
}
