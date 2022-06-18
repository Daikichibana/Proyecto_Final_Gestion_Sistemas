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
    public class AdministrarTarjetaClienteService : IAdministrarTarjetaClienteService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;



        public AdministrarTarjetaClienteService(IMapper mapper, BaseDatosContext context)
        {

            _unidad = new UnidadDeTrabajo(context);
            _mapper = mapper;
        }

        public IList<TarjetaClienteDTO> ActualizarTarjetaCliente(IList<TarjetaClienteDTO> entity)
        {
            var listaTarjetaConvertida = _mapper.Map<List<TarjetaCliente>>(entity);
            List<TarjetaCliente> result = new List<TarjetaCliente>();
            foreach (var tarjeta in listaTarjetaConvertida)
            {
                var tarjetaInsertada = _unidad.tarjetaClienteRepository.Actualizar(tarjeta);
                result.Add(tarjetaInsertada);
            }
            _unidad.Complete();
            return _mapper.Map<List<TarjetaClienteDTO>>(result);
        }

        public void EliminarTarjetaCliente(Guid id)
        {
            _unidad.tarjetaClienteRepository.Eliminar(id);
            _unidad.Complete();
        }

        public IList<TarjetaClienteDTO> GuardarTarjetaCliente(IList<TarjetaClienteDTO> entity)
        {

            var listaTarjetaConvertida = _mapper.Map<List<TarjetaCliente>>(entity);
            List<TarjetaCliente> result = new List<TarjetaCliente>();
            foreach (var tarjeta in listaTarjetaConvertida)
            {
                var tarjetaInsertada = _unidad.tarjetaClienteRepository.Guardar(tarjeta);
                result.Add(tarjetaInsertada);
            }
            _unidad.Complete();
            return _mapper.Map<List<TarjetaClienteDTO>>(result);

        }

        public TarjetaClienteDTO ObtenerPorIdTarjetaCliente(Guid id)
        {

            var tarjeta = _unidad.tarjetaClienteRepository.ObtenerPorId(id);
            tarjeta.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(tarjeta.EmpresaClienteId);
            tarjeta.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(tarjeta.EmpresaCliente.RubroId);
            tarjeta.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(tarjeta.EmpresaCliente.NITId);
            tarjeta.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(tarjeta.EmpresaCliente.ResponsableId);
            tarjeta.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(tarjeta.EmpresaCliente.Responsable.UsuarioId);
            return _mapper.Map<TarjetaClienteDTO>(tarjeta);

        }

        public IList<TarjetaClienteDTO> ObtenerTodoTarjetaCliente()
        {

            var listaTarjeta = _unidad.tarjetaClienteRepository.ObtenerTodo();
            foreach (var tarjeta in listaTarjeta)
            {
                tarjeta.EmpresaCliente = _unidad.empresaClienteRepository.ObtenerPorId(tarjeta.EmpresaClienteId);
                tarjeta.EmpresaCliente.Rubro = _unidad.rubroRepository.ObtenerPorId(tarjeta.EmpresaCliente.RubroId);
                tarjeta.EmpresaCliente.NIT = _unidad.nitRepository.ObtenerPorId(tarjeta.EmpresaCliente.NITId);
                tarjeta.EmpresaCliente.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(tarjeta.EmpresaCliente.ResponsableId);
                tarjeta.EmpresaCliente.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(tarjeta.EmpresaCliente.Responsable.UsuarioId);
            }
            return _mapper.Map<List<TarjetaClienteDTO>>(listaTarjeta);

        }
    }
}
