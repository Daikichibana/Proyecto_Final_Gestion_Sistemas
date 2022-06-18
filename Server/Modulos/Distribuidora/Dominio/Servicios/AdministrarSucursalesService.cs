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
    public class AdministrarSucursalesService : IAdministrarSucursalesService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidad;
        public AdministrarSucursalesService(IMapper mapper, BaseDatosContext context)
        {
            _unidad = new UnidadDeTrabajo(context);
            _mapper = mapper;
        }
        public IList<SucursalesDTO> ActualizarSucursales(IList<SucursalesDTO> entity)
        {
            var listaSucursalesConvertida = _mapper.Map<List<Sucursales>>(entity);
            List<Sucursales> result = new List<Sucursales>();
            foreach (var sucursal in listaSucursalesConvertida)
            {
                var sucursalInsertada = _unidad.sucursalesRepository.Actualizar(sucursal);
                result.Add(sucursalInsertada);
            }
            _unidad.Complete();
            return _mapper.Map<List<SucursalesDTO>>(result);
        }
        public void EliminarSucursales(Guid id)
        {
            _unidad.sucursalesRepository.Eliminar(id);
            _unidad.Complete();
        }
        public IList<SucursalesDTO> GuardarSucursales(IList<SucursalesDTO> entity)
        {
            var listaSucursalesConvertida = _mapper.Map<List<Sucursales>>(entity);
            List<Sucursales> result = new List<Sucursales>();
            foreach (var sucursal in listaSucursalesConvertida)
            {
                var sucursalInsertada = _unidad.sucursalesRepository.Guardar(sucursal);
                result.Add(sucursalInsertada);
            }
            _unidad.Complete();
            return _mapper.Map<List<SucursalesDTO>>(result);
        }
        public SucursalesDTO ObtenerPorIdSucursales(Guid id)
        {
            var sucursal = _unidad.sucursalesRepository.ObtenerPorId(id);
            sucursal.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(sucursal.EmpresaDistribuidoraId);
            sucursal.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.NITId);
            sucursal.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.ResponsableId);
            sucursal.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.Responsable.UsuarioId);
            sucursal.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.RubroId);
            return _mapper.Map<SucursalesDTO>(sucursal);
        }
        public IList<SucursalesDTO> ObtenerTodoSucursales()
        {
            var listaSucursal = _unidad.sucursalesRepository.ObtenerTodo();
            foreach (var sucursal in listaSucursal)
            {
                sucursal.EmpresaDistribuidora = _unidad.distribuidoraRepository.ObtenerPorId(sucursal.EmpresaDistribuidoraId);
                sucursal.EmpresaDistribuidora.NIT = _unidad.nitRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.NITId);
                sucursal.EmpresaDistribuidora.Responsable = _unidad.responsableDistribuidoraRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.ResponsableId);
                sucursal.EmpresaDistribuidora.Responsable.Usuario = _unidad.usuarioRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.Responsable.UsuarioId);
                sucursal.EmpresaDistribuidora.Rubro = _unidad.rubroRepository.ObtenerPorId(sucursal.EmpresaDistribuidora.RubroId);
            }
            return _mapper.Map<List<SucursalesDTO>>(listaSucursal);
        }
    }
}
