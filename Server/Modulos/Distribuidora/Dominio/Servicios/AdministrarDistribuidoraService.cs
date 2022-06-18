using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarDistribuidoraService : IAdministrarDistribuidoraService
    {
        UnidadDeTrabajo _unidadDeTrabajo;
        IMapper _mapper;

        public AdministrarDistribuidoraService(IMapper mapper, UnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _mapper = mapper;
        }
        public EmpresaDistribuidoraDTO ActualizarDistribuidora(EmpresaDistribuidoraDTO entity)
        {
            var distribuidora = _mapper.Map<EmpresaDistribuidora>(entity);
            var distribuidorasRegistradas = _unidadDeTrabajo.distribuidoraRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(distribuidora.NombreEmpresa)).ToList();
            if (distribuidorasRegistradas.Count > 0)
                throw new Exception("Ya existe una distribuidora registrada con ese nombre");
            
            var distribuidoraActualizada = _unidadDeTrabajo.distribuidoraRepository.Actualizar(distribuidora);
            _unidadDeTrabajo.distribuidoraRepository.GuardarCambios();

            return _mapper.Map<EmpresaDistribuidoraDTO>(distribuidoraActualizada);
        }
        public void EliminarDistribuidora(Guid id)
        {
            var distribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerPorId(id);

            _unidadDeTrabajo.usuarioRepository.Eliminar(distribuidora.Responsable.UsuarioId);
            _unidadDeTrabajo.responsableDistribuidoraRepository.Eliminar(distribuidora.ResponsableId);
            _unidadDeTrabajo.nitRepository.Eliminar(distribuidora.NITId);
            _unidadDeTrabajo.distribuidoraRepository.Eliminar(id);

            _unidadDeTrabajo.usuarioRepository.GuardarCambios();
            _unidadDeTrabajo.responsableDistribuidoraRepository.GuardarCambios();
            _unidadDeTrabajo.nitRepository.GuardarCambios();
            _unidadDeTrabajo.distribuidoraRepository.GuardarCambios();
        }
        public EmpresaDistribuidoraDTO GuardarDistribuidora(EmpresaDistribuidoraDTO entity)
        {
            var distribuidora = _mapper.Map<EmpresaDistribuidora>(entity);
            var distribuidorasRegistradas = _unidadDeTrabajo.distribuidoraRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(distribuidora.NombreEmpresa)).ToList();
            if (distribuidorasRegistradas.Count > 0)
                throw new Exception("Ya existe una distribuidora registrada con ese nombre");

            var distribuidoraActualizada = _unidadDeTrabajo.distribuidoraRepository.Guardar(distribuidora);
            _unidadDeTrabajo.distribuidoraRepository.GuardarCambios();

            return _mapper.Map<EmpresaDistribuidoraDTO>(distribuidoraActualizada);
        }
        public EmpresaDistribuidoraDTO ObtenerPorIdDistribuidora(Guid id)
        {
            var distribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerPorId(id);

            distribuidora.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(distribuidora.RubroId);
            distribuidora.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(distribuidora.NITId);
            distribuidora.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(distribuidora.ResponsableId);
            distribuidora.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(distribuidora.Responsable.UsuarioId);

            return _mapper.Map<EmpresaDistribuidoraDTO>(distribuidora);
        }
        public IList<EmpresaDistribuidoraDTO> ObtenerTodoDistribuidora()
        {
            var item = _unidadDeTrabajo.distribuidoraRepository.ObtenerTodo();

            foreach(var distribuidora in item)
            {
                distribuidora.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(distribuidora.RubroId);
                distribuidora.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(distribuidora.NITId);
                distribuidora.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(distribuidora.ResponsableId);
                distribuidora.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(distribuidora.Responsable.UsuarioId);
            }

            return _mapper.Map<List<EmpresaDistribuidoraDTO>>(item);
        }
    }
}
