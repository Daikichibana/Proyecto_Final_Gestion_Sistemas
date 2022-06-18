using System;
using System.Collections.Generic;
using AutoMapper;
using Compartido.Dto.Personal.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Servicios
{
    public class AdministrarConductorService : IAdministrarConductorService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public AdministrarConductorService(IMapper mapper, BaseDatosContext contexto)
        {
            _unidad = new UnidadDeTrabajo(contexto);
            _mapper = mapper;
        }
        public IList<ConductorDTO> ActualizarConductor(IList<ConductorDTO> entity)
        {
            var ListaConductores = _mapper.Map<List<Conductor>>(entity);
            var result = new List<Conductor>();

            foreach (var conductor in ListaConductores)
            {
                result.Add(_unidad.conductorRepository.Actualizar(conductor));
            }

            _unidad.Complete();
            return _mapper.Map<List<ConductorDTO>>(result);
        }
        
        public void EliminarConductor(Guid id)
        {
            _unidad.conductorRepository.Eliminar(id);
            _unidad.Complete();
        }
        
        public IList<ConductorDTO> GuardarConductor(IList<ConductorDTO> entity)
        {
            var ListaConductores = _mapper.Map<List<Conductor>>(entity);
            var result = new List<Conductor>();

            foreach (var conductor in ListaConductores)
            {
                result.Add(_unidad.conductorRepository.Guardar(conductor));
            }

            _unidad.Complete();
            return _mapper.Map<List<ConductorDTO>>(result);
        }

        public ConductorDTO ObtenerPorIdConductor(Guid id)
        {
            var Conductor = _unidad.conductorRepository.ObtenerPorId(id);
            Conductor.Usuario = _unidad.usuarioRepository.ObtenerPorId(Conductor.UsuarioId);
            return _mapper.Map<ConductorDTO>(Conductor);
        }
        
        public IList<ConductorDTO> ObtenerTodoConductor()
        {
            var ListaConductores = _unidad.conductorRepository.ObtenerTodo();

            foreach (var conductor in ListaConductores)
            { 
                conductor.Usuario = _unidad.usuarioRepository.ObtenerPorId(conductor.UsuarioId);
            }

            return _mapper.Map<IList<ConductorDTO>>(ListaConductores);
        }

    }
}
