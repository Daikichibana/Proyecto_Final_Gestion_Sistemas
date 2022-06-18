﻿using System;
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
    public class AdministrarEmpresaClienteService : IAdministrarClienteService
    {
        UnidadDeTrabajo _unidadDeTrabajo;
        IMapper _mapper;
        public AdministrarEmpresaClienteService(IMapper mapper, UnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
            _mapper = mapper;
        }

        public EmpresaClienteDTO ActualizarCliente(EmpresaClienteDTO entity)
        {
            var cliente = _mapper.Map<EmpresaCliente>(entity);
            var clientesRegistrados = _unidadDeTrabajo.empresaClienteRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(cliente.NombreEmpresa)).ToList();
            if (clientesRegistrados.Count() > 0)
                throw new Exception("Ya existe un cliente registrado con ese nombre");
            
            var clienteActualizado = _unidadDeTrabajo.empresaClienteRepository.Actualizar(cliente);
            _unidadDeTrabajo.empresaClienteRepository.GuardarCambios();

            return _mapper.Map<EmpresaClienteDTO>(clienteActualizado);
        }

        public void EliminarCliente(Guid id)
        {
            var cliente = _unidadDeTrabajo.empresaClienteRepository.ObtenerPorId(id);

            _unidadDeTrabajo.usuarioRepository.Eliminar(cliente.Responsable.UsuarioId);
            _unidadDeTrabajo.responsableAlmacenRepository.Eliminar(cliente.ResponsableId);
            _unidadDeTrabajo.nitRepository.Eliminar(cliente.NITId);
            _unidadDeTrabajo.empresaClienteRepository.Eliminar(id);

            _unidadDeTrabajo.usuarioRepository.GuardarCambios();
            _unidadDeTrabajo.responsableDistribuidoraRepository.GuardarCambios();
            _unidadDeTrabajo.nitRepository.GuardarCambios();
            _unidadDeTrabajo.empresaClienteRepository.GuardarCambios();
        }

        public EmpresaClienteDTO GuardarCliente(EmpresaClienteDTO entity)
        {
            var cliente = _mapper.Map<EmpresaCliente>(entity);
            var clientesExistentes = _unidadDeTrabajo.empresaClienteRepository.ObtenerTodo().Where(p => p.NombreEmpresa.Equals(cliente.NombreEmpresa)).ToList();
            if (clientesExistentes.Count > 0) 
                throw new Exception("Ya existe un cliente registrado con ese nombre");

            var clienteResgitrado = _unidadDeTrabajo.empresaClienteRepository.Guardar(cliente);
            _unidadDeTrabajo.empresaClienteRepository.GuardarCambios();

            return _mapper.Map<EmpresaClienteDTO>(clienteResgitrado);
        }

        public EmpresaClienteDTO ObtenerPorIdCliente(Guid id)
        {
            var cliente = _unidadDeTrabajo.empresaClienteRepository.ObtenerPorId(id);

            cliente.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(cliente.RubroId);
            cliente.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(cliente.NITId);
            cliente.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(cliente.ResponsableId);
            cliente.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(cliente.Responsable.UsuarioId);

            return _mapper.Map<EmpresaClienteDTO>(cliente);
        }

        public IList<EmpresaClienteDTO> ObtenerTodoCliente()
        {
            var item = _unidadDeTrabajo.empresaClienteRepository.ObtenerTodo();
            foreach(var cliente in item)
            {
                cliente.Rubro = _unidadDeTrabajo.rubroRepository.ObtenerPorId(cliente.RubroId);
                cliente.NIT = _unidadDeTrabajo.nitRepository.ObtenerPorId(cliente.NITId);
                cliente.Responsable = _unidadDeTrabajo.responsableDistribuidoraRepository.ObtenerPorId(cliente.ResponsableId);
                cliente.Responsable.Usuario = _unidadDeTrabajo.usuarioRepository.ObtenerPorId(cliente.Responsable.UsuarioId);
            }
            return _mapper.Map<List<EmpresaClienteDTO>>(item);
        }

        public IList<ClientesDistribuidoraDTO> ObtenerDistribuidorasDeCliente(Guid id)
        {
            var distribuidoras = _unidadDeTrabajo.clienteDistribuidoraRepository.ObtenerTodo().Where(p => p.ClientesId.Equals(id));
            return _mapper.Map<IList<ClientesDistribuidoraDTO>>(distribuidoras);
        }

        public void EliminarDistribuidorasDeCliente(Guid Id) 
        {
            _unidadDeTrabajo.clienteDistribuidoraRepository.Eliminar(Id);

            _unidadDeTrabajo.clienteDistribuidoraRepository.GuardarCambios();
        }
        
        public ClientesDistribuidoraDTO InsertarDistribuidorasDeCliente(ClientesDistribuidoraDTO clienteDistribuidora)
        {
            var cd = _mapper.Map<ClientesDistribuidora>(clienteDistribuidora);

            _unidadDeTrabajo.clienteDistribuidoraRepository.Guardar(cd);
            _unidadDeTrabajo.clienteDistribuidoraRepository.GuardarCambios();

            return _mapper.Map<ClientesDistribuidoraDTO>(cd);                        
        }

    }
}
