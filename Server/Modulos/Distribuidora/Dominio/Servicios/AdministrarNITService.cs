using System;
using System.Collections.Generic;
using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarNITService : IAdministrarNITService
    {
        INITRepository _NITrepository;
        IMapper _mapper;

        public AdministrarNITService (IMapper mapper, INITRepository nITrepository)
        {
            _NITrepository = nITrepository;
            _mapper = mapper;
        }
        public NITDTO ActualizarNIT(NITDTO entity)
        {
            var nit = _mapper.Map<NIT>(entity);
            var nitActualizado = _NITrepository.Actualizar(nit);

            _NITrepository.GuardarCambios();
            return _mapper.Map<NITDTO>(nitActualizado);
        }
        public void EliminarNIT(Guid id)
        {
            _NITrepository.Eliminar(id);
            _NITrepository.GuardarCambios();
        }
        public NITDTO GuardarNIT(NITDTO entity)
        {
            var nit = _mapper.Map<NIT>(entity);
            _NITrepository.Guardar(nit);

            _NITrepository.GuardarCambios();
            return _mapper.Map<NITDTO>(nit);
        }
        public NITDTO ObtenerPorIdNIT(Guid id)
        {
            var nit = _mapper.Map<NIT>(_NITrepository.ObtenerPorId(id));
            return _mapper.Map<NITDTO>(nit);
        }
        public IList<NITDTO> ObtenerTodoNIT()
        {
            var nit = _NITrepository.ObtenerTodo();
            return _mapper.Map<IList<NITDTO>>(nit);
        }
    }
}
