using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarProveedorService : IAdministrarProveedorService
    {
        IMapper _mapper;
        UnidadDeTrabajo _unidadDeTrabajo;

        public AdministrarProveedorService(IMapper mapper, UnidadDeTrabajo unidadDeTrabajo)
        {
            _mapper = mapper;
            _unidadDeTrabajo = unidadDeTrabajo;

            
        }

        public List<EmpresaProveedorDTO> ActualizarProveedor(List<EmpresaProveedorDTO> entity)
        {
            var proveedores = _mapper.Map<List<EmpresaProveedor>>(entity);
            var proveedorActualizados = new List<EmpresaProveedor>();

            foreach(var proveedor in proveedores)
            {
                var proveedorExistente = _unidadDeTrabajo.empresaProveedorRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(proveedor.NombreEmpresa)).ToList();
                if (proveedorExistente.Count > 0)
                    if (proveedorExistente.FirstOrDefault().Id.Equals(proveedor.Id))
                        throw new Exception("Ya existe un proveedor con el mismo nombre");

                var proveedorActualizado = _unidadDeTrabajo.empresaProveedorRepository.Actualizar(proveedor);
                proveedorActualizados.Add(proveedorActualizado);
            }

            _unidadDeTrabajo.empresaProveedorRepository.GuardarCambios();
            return _mapper.Map<List<EmpresaProveedorDTO>>(proveedorActualizados);
        }

        public void EliminarProveedor(Guid id)
        {
            var proveedor = _unidadDeTrabajo.empresaProveedorRepository.ObtenerPorId(id);
            
            _unidadDeTrabajo.usuarioRepository.Eliminar(proveedor.Responsable.UsuarioId);
            _unidadDeTrabajo.responsableDistribuidoraRepository.Eliminar(proveedor.ResponsableId);
            _unidadDeTrabajo.nitRepository.Eliminar(proveedor.NITId);
            _unidadDeTrabajo.empresaProveedorRepository.Eliminar(id);

            _unidadDeTrabajo.empresaProveedorRepository.GuardarCambios();
            _unidadDeTrabajo.usuarioRepository.GuardarCambios();
            _unidadDeTrabajo.responsableDistribuidoraRepository.GuardarCambios();
            _unidadDeTrabajo.nitRepository.GuardarCambios();
        }

        public List<EmpresaProveedorDTO> GuardarProveedor(List<EmpresaProveedorDTO> entity)
        {
            var proveedores = _mapper.Map<List<EmpresaProveedor>>(entity);
            var proveedoresRegistrados = new List<EmpresaProveedor>();
            foreach(var prov in proveedores)
            {
                var proveedorExistente = _unidadDeTrabajo.empresaProveedorRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(prov.NombreEmpresa)).ToList();
                if (proveedorExistente.Count > 0)
                    throw new Exception("Un proveedor con el mismo nombre ya se necuentra registrado");

                var proveedorReg = _unidadDeTrabajo.empresaProveedorRepository.Guardar(prov);
                proveedoresRegistrados.Add(prov);
                                
            }
            _unidadDeTrabajo.empresaProveedorRepository.GuardarCambios();
            return _mapper.Map<List<EmpresaProveedorDTO>>(proveedoresRegistrados);

        }

        public EmpresaProveedorDTO ObtenerPorIdProveedor(Guid id)
        {
            var proveedor = _unidadDeTrabajo.empresaProveedorRepository.ObtenerPorId(id);

            proveedor.EmpresaDistribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerPorId(proveedor.EmpresaDistribuidoraId);
            proveedor.EmpresaDistribuidora.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.RubroId);
            proveedor.EmpresaDistribuidora.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.NITId);
            proveedor.EmpresaDistribuidora.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.ResponsableId);
            proveedor.EmpresaDistribuidora.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.Responsable.UsuarioId);
            proveedor.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(proveedor.RubroId);
            proveedor.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(proveedor.NITId);
            proveedor.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(proveedor.ResponsableId);
            proveedor.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(proveedor.Responsable.UsuarioId);

            return _mapper.Map<EmpresaProveedorDTO>(proveedor);
        }

        public IList<EmpresaProveedorDTO> ObtenerTodoProveedor()
        {
            var item = _unidadDeTrabajo.empresaProveedorRepository.ObtenerTodo();
            foreach(var proveedor in item)
            {
                proveedor.EmpresaDistribuidora = _unidadDeTrabajo.distribuidoraRepository.ObtenerPorId(proveedor.EmpresaDistribuidoraId);
                proveedor.EmpresaDistribuidora.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.RubroId);
                proveedor.EmpresaDistribuidora.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.NITId);
                proveedor.EmpresaDistribuidora.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.ResponsableId);
                proveedor.EmpresaDistribuidora.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.Responsable.UsuarioId);
                proveedor.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(proveedor.RubroId);
                proveedor.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(proveedor.NITId);
                proveedor.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(proveedor.ResponsableId);
                proveedor.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(proveedor.Responsable.UsuarioId);

            }

            return _mapper.Map<List<EmpresaProveedorDTO>>(item);
        }

    }
}
