using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarVehiculoService : IAdministrarVehiculoService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public AdministrarVehiculoService(IMapper mapper, BaseDatosContext context)
        {
            _unidad = new UnidadDeTrabajo(context);
            _mapper = mapper;
        }
        public IList<VehiculoDTO> ActualizarVehiculo(IList<VehiculoDTO> entity)
        {
            var listaVehiculoConvertido = _mapper.Map<List<Vechiculo>>(entity);
            List<Vechiculo> result = new List<Vechiculo>();
            foreach (var vehiculo in listaVehiculoConvertido)
            {
                var vehiculoInsertado = _unidad.vechiculoRepository.Actualizar(vehiculo);
                result.Add(vehiculoInsertado);
            }
            _unidad.Complete();
            return _mapper.Map<List<VehiculoDTO>>(result);
        }
        public void EliminarVehiculo(Guid id)
        {
            _unidad.vechiculoRepository.Eliminar(id);
            _unidad.Complete();
        }
        public IList<VehiculoDTO> GuardarVehiculo(IList<VehiculoDTO> entity)
        {
             var listaVehiculoConvertido = _mapper.Map<List<Vechiculo>>(entity);
            List<Vechiculo> result = new List<Vechiculo>();
            foreach (var vehiculo in listaVehiculoConvertido)
            {
                var vehiculoInsertado = _unidad.vechiculoRepository.Guardar(vehiculo);
                result.Add(vehiculoInsertado);
            }
            _unidad.Complete();
            return _mapper.Map<List<VehiculoDTO>>(result);
        }
        public VehiculoDTO ObtenerPorIdVehiculo(Guid id)
        {
            var vehiculo = _unidad.vechiculoRepository.ObtenerPorId(id);

            return _mapper.Map<VehiculoDTO>(vehiculo);
        }
        public IList<VehiculoDTO> ObtenerTodoVehiculo()
        {
            var listaVehiculo = _unidad.vechiculoRepository.ObtenerTodo();
            return _mapper.Map<List<VehiculoDTO>>(listaVehiculo);
        }


        public void AsignarVehiculoAConductor(AsignacionVechiculoConductorDTO vhconductor)
        {
            _unidad.asignacionVechiculoConductorRepository.Guardar(_mapper.Map<AsignacionVechiculoConductor>(vhconductor));
            _unidad.Complete();
        }

        public IList<AsignacionVechiculoConductorDTO> ObtenerTodoAsignacionVechiculo()
        {
            var listaAsignacionVehiculo = _unidad.asignacionVechiculoConductorRepository.ObtenerTodo();
            foreach(var asignacion in listaAsignacionVehiculo)
            {
                asignacion.Conductor = _unidad.conductorRepository.ObtenerPorId(asignacion.ConductorId);

                asignacion.Conductor.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(asignacion.Conductor.EmpresaDistribuidoraId);
                asignacion.Conductor.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(asignacion.Conductor.EmpresaDistribuidora.NITId);
                asignacion.Conductor.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(asignacion.Conductor.EmpresaDistribuidora.ResponsableId);
                asignacion.Conductor.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(asignacion.Conductor.EmpresaDistribuidora.Responsable.UsuarioId);
                asignacion.Conductor.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(asignacion.Conductor.EmpresaDistribuidora.RubroId);
                asignacion.Vechiculo = _unidad.vechiculoRepository.ObtenerPorId(asignacion.VechiculoId);
                asignacion.Vechiculo.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(asignacion.Vechiculo.EmpresaDistribuidoraId);
                asignacion.Vechiculo.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(asignacion.Vechiculo.EmpresaDistribuidora.NITId);
                asignacion.Vechiculo.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(asignacion.Vechiculo.EmpresaDistribuidora.ResponsableId);
                asignacion.Vechiculo.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(asignacion.Vechiculo.EmpresaDistribuidora.Responsable.UsuarioId);
                asignacion.Vechiculo.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(asignacion.Vechiculo.EmpresaDistribuidora.RubroId);
                
            }

            return _mapper.Map<List<AsignacionVechiculoConductorDTO>>(listaAsignacionVehiculo);
        }
    }
}
