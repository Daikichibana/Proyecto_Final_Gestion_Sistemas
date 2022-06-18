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
    public class AdministrarEmpresaClienteService : IAdministrarClienteService
    {
        IEmpresaClienteRepository _EmpresaClienteRepository;
        IClienteDistribuidoraRepository _ClienteDistribuidoraRepository;
        IRubroRepository _RubroRepository;
        INITRepository _NITRepository;
        IResponsableEmpresaRepository _ResponsableEmpresaRepository;
        IUsuarioRepository _usuarioRepository;
        IMapper _mapper;
        public AdministrarEmpresaClienteService(IMapper mapper,IUsuarioRepository usuarioRepository, IResponsableEmpresaRepository responsableEmpresaRepository, INITRepository nITRepository, IRubroRepository rubroRepository, IEmpresaClienteRepository EmpresaClienteRepository, IClienteDistribuidoraRepository ClienteDistribuidoraRepository)
        {
            _ClienteDistribuidoraRepository = ClienteDistribuidoraRepository;
            _EmpresaClienteRepository = EmpresaClienteRepository;
            _RubroRepository = rubroRepository;
            _NITRepository = nITRepository;
            _ResponsableEmpresaRepository = responsableEmpresaRepository;
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }

        public EmpresaClienteDTO ActualizarCliente(EmpresaClienteDTO entity)
        {
            var cliente = _mapper.Map<EmpresaCliente>(entity);
            var clientesRegistrados = _EmpresaClienteRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(cliente.NombreEmpresa)).ToList();
            if (clientesRegistrados.Count() > 0)
                throw new Exception("Ya existe un cliente registrado con ese nombre");
            
            var clienteActualizado = _EmpresaClienteRepository.Actualizar(cliente);
            _EmpresaClienteRepository.GuardarCambios();

            return _mapper.Map<EmpresaClienteDTO>(clienteActualizado);
        }

        public void EliminarCliente(Guid id)
        {

            _EmpresaClienteRepository.Eliminar(id);

            _EmpresaClienteRepository.GuardarCambios();
        }

        public EmpresaClienteDTO GuardarCliente(EmpresaClienteDTO entity)
        {
            var cliente = _mapper.Map<EmpresaCliente>(entity);
            var clientesExistentes = _EmpresaClienteRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(cliente.NombreEmpresa)).ToList();
            if (clientesExistentes.Count > 0) 
                throw new Exception("Ya existe un cliente registrado con ese nombre");

            var clienteResgitrado = _EmpresaClienteRepository.Guardar(cliente);
            _EmpresaClienteRepository.GuardarCambios();

            return _mapper.Map<EmpresaClienteDTO>(clienteResgitrado);
        }

        public EmpresaClienteDTO ObtenerPorIdCliente(Guid id)
        {
            var cliente = _EmpresaClienteRepository.ObtenerPorId(id);

            cliente.Rubro = _RubroRepository.ObtenerPorId(cliente.RubroId);
            cliente.NIT = _NITRepository.ObtenerPorId(cliente.NITId);
            cliente.Responsable = _ResponsableEmpresaRepository.ObtenerPorId(cliente.ResponsableId);
            cliente.Responsable.Usuario = _usuarioRepository.ObtenerPorId(cliente.Responsable.UsuarioId);

            return _mapper.Map<EmpresaClienteDTO>(cliente);
        }

        public IList<EmpresaClienteDTO> ObtenerTodoCliente()
        {
            var item = _EmpresaClienteRepository.ObtenerTodo();
            foreach(var cliente in item)
            {
                cliente.Rubro = _RubroRepository.ObtenerPorId(cliente.RubroId);
                cliente.NIT = _NITRepository.ObtenerPorId(cliente.NITId);
                cliente.Responsable = _ResponsableEmpresaRepository.ObtenerPorId(cliente.ResponsableId);
                cliente.Responsable.Usuario = _usuarioRepository.ObtenerPorId(cliente.Responsable.UsuarioId);
            }
            return _mapper.Map<List<EmpresaClienteDTO>>(item);
        }

        public IList<ClientesDistribuidoraDTO> ObtenerDistribuidorasDeCliente(Guid id)
        {
            var distribuidoras = _ClienteDistribuidoraRepository.ObtenerTodo().Where(p => p.ClientesId.Equals(id));
            return _mapper.Map<IList<ClientesDistribuidoraDTO>>(distribuidoras);
        }

        public void EliminarDistribuidorasDeCliente(Guid Id) 
        {
            _ClienteDistribuidoraRepository.Eliminar(Id);

            _ClienteDistribuidoraRepository.GuardarCambios();
        }
        
        public ClientesDistribuidoraDTO InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO clienteDistribuidora)
        {
            var cd = _mapper.Map<ClientesDistribuidora>(clienteDistribuidora);

            _ClienteDistribuidoraRepository.Guardar(cd);
            _ClienteDistribuidoraRepository.GuardarCambios();

            return _mapper.Map<ClientesDistribuidoraDTO>(cd);                        
        }

    }
}
