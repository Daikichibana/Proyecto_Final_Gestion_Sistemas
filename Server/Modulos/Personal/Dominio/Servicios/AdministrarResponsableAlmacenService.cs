using System;
using System.Collections.Generic;
using AutoMapper;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarResponsableAlmacenService : IAdministrarResponsableAlmacenService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public AdministrarResponsableAlmacenService(IMapper mapper, BaseDatosContext contexto)
        {
            _unidad = new UnidadDeTrabajo(contexto);
            _mapper = mapper;
        }
        public IList<ResponsableAlmacenDTO> ActualizarResponsableAlmacen(IList<ResponsableAlmacenDTO> entity)
        {
            var ListaReponsable = _mapper.Map<List<ResponsableAlmacen>>(entity);
            var result = new List<ResponsableAlmacen>();

            foreach (var responsable in ListaReponsable) 
            {
                result.Add(_unidad.responsableAlmacenRepository.Actualizar(responsable));
            }

            _unidad.Complete();
            return _mapper.Map<List<ResponsableAlmacenDTO>>(result);
        }
        public void EliminarResponsableAlmacen(Guid id)
        {
            _unidad.responsableAlmacenRepository.Eliminar(id);
            _unidad.Complete();
        }
        public IList<ResponsableAlmacenDTO> GuardarResponsableAlmacen(IList<ResponsableAlmacenDTO> entity)
        {
            var ListaReponsable = _mapper.Map<List<ResponsableAlmacen>>(entity);
            var result = new List<ResponsableAlmacen>();

            foreach (var responsable in ListaReponsable)
            {
                result.Add(_unidad.responsableAlmacenRepository.Guardar(responsable));
            }

            _unidad.Complete();
            return _mapper.Map<List<ResponsableAlmacenDTO>>(result);
        }

        public ResponsableAlmacenDTO ObtenerPorIdResponsableAlmacen(Guid id)
        {
            var responsable = _unidad.responsableAlmacenRepository.ObtenerPorId(id);
            responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(responsable.UsuarioId);
            responsable.Distribuidora = _unidad.distribuidoraRepository.ObtenerPorId(responsable.DistribuidoraId);
            responsable.Distribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(responsable.Distribuidora.RubroId);
            responsable.Distribuidora.NIT = _unidad.nitRepository.ObtenerPorId(responsable.Distribuidora.NITId);
            responsable.Distribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(responsable.Distribuidora.ResponsableId);
            responsable.Distribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(responsable.Distribuidora.Responsable.UsuarioId);

            return _mapper.Map<ResponsableAlmacenDTO>(responsable);
        }
        public IList<ResponsableAlmacenDTO> ObtenerTodoResponsableAlmacen()
        {
            var ListaResponsable = _unidad.responsableAlmacenRepository.ObtenerTodo();

            foreach (var responsable in ListaResponsable) 
            {
                responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(responsable.UsuarioId);
                responsable.Distribuidora = _unidad.distribuidoraRepository.ObtenerPorId(responsable.DistribuidoraId);
                responsable.Distribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(responsable.Distribuidora.RubroId);
                responsable.Distribuidora.NIT = _unidad.nitRepository.ObtenerPorId(responsable.Distribuidora.NITId);
                responsable.Distribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(responsable.Distribuidora.ResponsableId);
                responsable.Distribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(responsable.Distribuidora.Responsable.UsuarioId);
            }

            return _mapper.Map<List<ResponsableAlmacenDTO>>(ListaResponsable);
        }

    }
}
