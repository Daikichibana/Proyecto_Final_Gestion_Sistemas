using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarDistribuidoraService : IAdministrarDistribuidoraService
    {
        IEmpresaDistribuidoraRepository _empresaDistribuidoraRepository;
        IRubroRepository _rubroRepository;
        INITRepository _nITRepository;
        IResponsableEmpresaRepository _responsableEmpresaRepository;
        IUsuarioRepository _usuarioRepository;
        IMapper _mapper;

        public AdministrarDistribuidoraService(IMapper mapper,IUsuarioRepository usuarioRepository, IResponsableEmpresaRepository responsableEmpresaRepository, INITRepository nITRepository, IRubroRepository rubroRepository, IEmpresaDistribuidoraRepository empresaDistribuidoraRepository)
        {
            _empresaDistribuidoraRepository = empresaDistribuidoraRepository;
            _rubroRepository = rubroRepository;
            _nITRepository = nITRepository;
            _responsableEmpresaRepository = responsableEmpresaRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        public EmpresaDistribuidoraDTO ActualizarDistribuidora(EmpresaDistribuidoraDTO entity)
        {
            var distribuidora = _mapper.Map<EmpresaDistribuidora>(entity);
            var distribuidorasRegistradas = _empresaDistribuidoraRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(distribuidora.NombreEmpresa)).ToList();
            if (distribuidorasRegistradas.Count > 0)
                throw new Exception("Ya existe una distribuidora registrada con ese nombre");
            
            var distribuidoraActualizada = _empresaDistribuidoraRepository.Actualizar(distribuidora);
            _empresaDistribuidoraRepository.GuardarCambios();

            return _mapper.Map<EmpresaDistribuidoraDTO>(distribuidoraActualizada);
        }
        public void EliminarDistribuidora(Guid id)
        {
            var distribuidora = _empresaDistribuidoraRepository.ObtenerPorId(id);

            _usuarioRepository.Eliminar(distribuidora.Responsable.UsuarioId);
            _responsableEmpresaRepository.Eliminar(distribuidora.ResponsableId);
            _nITRepository.Eliminar(distribuidora.NITId);
            _empresaDistribuidoraRepository.Eliminar(id);

            _usuarioRepository.GuardarCambios();
            _responsableEmpresaRepository.GuardarCambios();
            _nITRepository.GuardarCambios();
            _empresaDistribuidoraRepository.GuardarCambios();
        }
        public EmpresaDistribuidoraDTO GuardarDistribuidora(EmpresaDistribuidoraDTO entity)
        {
            var distribuidora = _mapper.Map<EmpresaDistribuidora>(entity);
            var distribuidorasRegistradas = _empresaDistribuidoraRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(distribuidora.NombreEmpresa)).ToList();
            if (distribuidorasRegistradas.Count > 0)
                throw new Exception("Ya existe una distribuidora registrada con ese nombre");

            var distribuidoraActualizada = _empresaDistribuidoraRepository.Guardar(distribuidora);
            _empresaDistribuidoraRepository.GuardarCambios();

            return _mapper.Map<EmpresaDistribuidoraDTO>(distribuidoraActualizada);
        }
        public EmpresaDistribuidoraDTO ObtenerPorIdDistribuidora(Guid id)
        {
            var distribuidora = _empresaDistribuidoraRepository.ObtenerPorId(id);

            distribuidora.Rubro = _rubroRepository.ObtenerPorId(distribuidora.RubroId);
            distribuidora.NIT = _nITRepository.ObtenerPorId(distribuidora.NITId);
            distribuidora.Responsable = _responsableEmpresaRepository.ObtenerPorId(distribuidora.ResponsableId);
            distribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(distribuidora.Responsable.UsuarioId);

            return _mapper.Map<EmpresaDistribuidoraDTO>(distribuidora);
        }
        public IList<EmpresaDistribuidoraDTO> ObtenerTodoDistribuidora()
        {
            var item = _empresaDistribuidoraRepository.ObtenerTodo();

            foreach(var distribuidora in item)
            {
                distribuidora.Rubro = _rubroRepository.ObtenerPorId(distribuidora.RubroId);
                distribuidora.NIT = _nITRepository.ObtenerPorId(distribuidora.NITId);
                distribuidora.Responsable = _responsableEmpresaRepository.ObtenerPorId(distribuidora.ResponsableId);
                distribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(distribuidora.Responsable.UsuarioId);
            }

            return _mapper.Map<List<EmpresaDistribuidoraDTO>>(item);
        }
    }
}
