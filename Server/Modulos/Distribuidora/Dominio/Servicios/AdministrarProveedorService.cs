using AutoMapper;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarProveedorService : IAdministrarProveedorService
    {
        IMapper _mapper;
        IProveedorRepository _proveedorRepository;
        IEmpresaDistribuidoraRepository _empresaDistribuidoraRepository;
        IRubroRepository _rubroRepository;
        INITRepository _NITRepository;
        IResponsableEmpresaRepository _responsableEmpresaRepository;
        IUsuarioRepository _usuarioRepository;

        public AdministrarProveedorService(IMapper mapper,IProveedorRepository proveedorRepository,IUsuarioRepository usuarioRepository, IEmpresaDistribuidoraRepository empresaDistribuidoraRepository, IRubroRepository rubroRepository, INITRepository nITRepository, IResponsableEmpresaRepository responsableEmpresaRepository)
        {
            _mapper = mapper;
            _proveedorRepository = proveedorRepository;
            _empresaDistribuidoraRepository = empresaDistribuidoraRepository;
            _rubroRepository = rubroRepository;
            _NITRepository = nITRepository;
            _responsableEmpresaRepository = responsableEmpresaRepository;
            _usuarioRepository = usuarioRepository;

            
        }

        public List<EmpresaProveedorDTO> ActualizarProveedor(List<EmpresaProveedorDTO> entity)
        {
            var proveedores = _mapper.Map<List<EmpresaProveedor>>(entity);
            var proveedorActualizados = new List<EmpresaProveedor>();

            foreach(var proveedor in proveedores)
            {
                var proveedorExistente = _proveedorRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(proveedor.NombreEmpresa)).ToList();
                if (proveedorExistente.Count > 0)
                    if (proveedorExistente.FirstOrDefault().Id.Equals(proveedor.Id))
                        throw new Exception("Ya existe un proveedor con el mismo nombre");

                var proveedorActualizado = _proveedorRepository.Actualizar(proveedor);
                proveedorActualizados.Add(proveedorActualizado);
            }

            _proveedorRepository.GuardarCambios();
            return _mapper.Map<List<EmpresaProveedorDTO>>(proveedorActualizados);
        }

        public void EliminarProveedor(Guid id)
        {
            var proveedor = _proveedorRepository.ObtenerPorId(id);
            
            _usuarioRepository.Eliminar(proveedor.Responsable.UsuarioId);
            _responsableEmpresaRepository.Eliminar(proveedor.ResponsableId);
            _NITRepository.Eliminar(proveedor.NITId);
            _proveedorRepository.Eliminar(id);

            _proveedorRepository.GuardarCambios();
            _usuarioRepository.GuardarCambios();
            _responsableEmpresaRepository.GuardarCambios();
            _NITRepository.GuardarCambios();
        }

        public List<EmpresaProveedorDTO> GuardarProveedor(List<EmpresaProveedorDTO> entity)
        {
            var proveedores = _mapper.Map<List<EmpresaProveedor>>(entity);
            var proveedoresRegistrados = new List<EmpresaProveedor>();
            foreach(var prov in proveedores)
            {
                var proveedorExistente = _proveedorRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(prov.NombreEmpresa)).ToList();
                if (proveedorExistente.Count > 0)
                    throw new Exception("Un proveedor con el mismo nombre ya se necuentra registrado");

                var proveedorReg = _proveedorRepository.Guardar(prov);
                proveedoresRegistrados.Add(prov);
                                
            }
            _proveedorRepository.GuardarCambios();
            return _mapper.Map<List<EmpresaProveedorDTO>>(proveedoresRegistrados);

        }

        public EmpresaProveedorDTO ObtenerPorIdProveedor(Guid id)
        {
            var proveedor = _proveedorRepository.ObtenerPorId(id);

            proveedor.EmpresaDistribuidora = _empresaDistribuidoraRepository.ObtenerPorId(proveedor.EmpresaDistribuidoraId);
            proveedor.EmpresaDistribuidora.Rubro = _rubroRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.RubroId);
            proveedor.EmpresaDistribuidora.NIT = _NITRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.NITId);
            proveedor.EmpresaDistribuidora.Responsable = _responsableEmpresaRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.ResponsableId);
            proveedor.EmpresaDistribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.Responsable.UsuarioId);
            proveedor.Rubro = _rubroRepository.ObtenerPorId(proveedor.RubroId);
            proveedor.NIT = _NITRepository.ObtenerPorId(proveedor.NITId);
            proveedor.Responsable = _responsableEmpresaRepository.ObtenerPorId(proveedor.ResponsableId);
            proveedor.Responsable.Usuario = _usuarioRepository.ObtenerPorId(proveedor.Responsable.UsuarioId);

            return _mapper.Map<EmpresaProveedorDTO>(proveedor);
        }

        public IList<EmpresaProveedorDTO> ObtenerTodoProveedor()
        {
            var item = _proveedorRepository.ObtenerTodo();
            foreach(var proveedor in item)
            {
                proveedor.EmpresaDistribuidora = _empresaDistribuidoraRepository.ObtenerPorId(proveedor.EmpresaDistribuidoraId);
                proveedor.EmpresaDistribuidora.Rubro = _rubroRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.RubroId);
                proveedor.EmpresaDistribuidora.NIT = _NITRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.NITId);
                proveedor.EmpresaDistribuidora.Responsable = _responsableEmpresaRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.ResponsableId);
                proveedor.EmpresaDistribuidora.Responsable.Usuario = _usuarioRepository.ObtenerPorId(proveedor.EmpresaDistribuidora.Responsable.UsuarioId);
                proveedor.Rubro = _rubroRepository.ObtenerPorId(proveedor.RubroId);
                proveedor.NIT = _NITRepository.ObtenerPorId(proveedor.NITId);
                proveedor.Responsable = _responsableEmpresaRepository.ObtenerPorId(proveedor.ResponsableId);
                proveedor.Responsable.Usuario = _usuarioRepository.ObtenerPorId(proveedor.Responsable.UsuarioId);

            }

            return _mapper.Map<List<EmpresaProveedorDTO>>(item);
        }

    }
}
