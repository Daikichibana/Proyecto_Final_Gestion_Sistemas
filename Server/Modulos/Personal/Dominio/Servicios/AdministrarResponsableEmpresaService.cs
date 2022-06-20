using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarResponsableEmpresaService : IResponsableEmpresaService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidadDeTrabajo;

        public AdministrarResponsableEmpresaService(IMapper mapper, BaseDatosContext context)
        {
            _mapper = mapper;
            _unidadDeTrabajo = new UnidadDeTrabajo(context);
        }
        public ResponsableEmpresaDTO ActualizarResponsableEmpresa(ResponsableEmpresaDTO entity)
        {
            var reponsable = _mapper.Map<ResponsableEmpresa>(entity);
            var responsableRegistrados = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerTodo().Where(p => p.Nombre.Equals(reponsable.Nombre)).ToList();
            if (responsableRegistrados.Count > 0)
                throw new Exception("Ya existe un responsable registrado con ese nombre");

            var responsableActualizado = _unidadDeTrabajo.responsableDistribuidoraRepository.Actualizar(reponsable);
            _unidadDeTrabajo.Complete();

            return _mapper.Map<ResponsableEmpresaDTO>(responsableActualizado);
        }
        public void EliminarResponsableEmpresa(Guid id)
        {
            _unidadDeTrabajo.responsableDistribuidoraRepository.Eliminar(id);

            _unidadDeTrabajo.Complete();
        }
        public ResponsableEmpresaDTO GuardarResponsableEmpresa(ResponsableEmpresaDTO entity)
        {
            var reponsable = _mapper.Map<ResponsableEmpresa>(entity);
            var responsableRegistrados = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerTodo().Where(p => p.Nombre.Equals(reponsable.Nombre)).ToList();
            if (responsableRegistrados.Count > 0)
                throw new Exception("Ya existe un responsable registrado con ese nombre");

            var responsableActualizado = _unidadDeTrabajo.responsableDistribuidoraRepository.Guardar(reponsable);
            _unidadDeTrabajo.Complete();

            return _mapper.Map<ResponsableEmpresaDTO>(responsableActualizado);
        }
        public ResponsableEmpresaDTO ObtenerPorIdResponsableEmpresa(Guid id)
        {
            var responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(id);

            responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(responsable.UsuarioId);

            return _mapper.Map<ResponsableEmpresaDTO>(responsable);
        }

        public IList<ResponsableEmpresaDTO> ObtenerTodoResponsableEmpresa()
        {
            var responsables = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerTodo().ToList();
            foreach (var item in responsables)
                item.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(item.UsuarioId);

            return _mapper.Map<List<ResponsableEmpresaDTO>>(responsables);
        }
    }
}
