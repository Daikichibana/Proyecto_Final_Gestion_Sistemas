using AutoMapper;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Servicios
{
    public class AdministrarNotaRecepcionService : IAdministrarNotaRecepcionService
    {
        UnidadDeTrabajo _unidadDeTrabajo;
        IMapper _mapper;
        public AdministrarNotaRecepcionService(BaseDatosContext context, IMapper mapper) {
            _unidadDeTrabajo = new UnidadDeTrabajo(context);
            _mapper = mapper;
        }

        public NotaRecepcionDTO GuardarNotaRecepcion(NotaRecepcionDTO entity)
        {
            var nota = _mapper.Map<NotaRecepcion>(entity);

            _unidadDeTrabajo.notaRecepcionRepository.Guardar(nota);
            _unidadDeTrabajo.Complete();

            return _mapper.Map<NotaRecepcionDTO>(nota);
        }

        public NotaRecepcionDTO ObtenerPorIdNotaRecepcion(Guid id)
        {
            var nota = _unidadDeTrabajo.notaRecepcionRepository.ObtenerPorId(id);

            nota.Proveedor = _unidadDeTrabajo.empresaProveedorRepository.ObtenerPorId(nota.ProveedorId);
            nota.Distribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerPorId(nota.DistribuidoraId);

            return _mapper.Map<NotaRecepcionDTO>(nota);
        }

        public IList<NotaRecepcionDTO> ObtenerTodoNotaRecepcion()
        {
            var notas = _unidadDeTrabajo.notaRecepcionRepository.ObtenerTodo();

            foreach( var item in notas)
            {
                item.Proveedor = _unidadDeTrabajo.empresaProveedorRepository.ObtenerPorId(item.ProveedorId);
                item.Distribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerPorId(item.DistribuidoraId);
            }

            return _mapper.Map<IList<NotaRecepcionDTO>>(notas);
        }
    }
}
