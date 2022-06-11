using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Tecnica;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Servicios
{
    public class AdministrarTarjetaClienteService : IAdministrarTarjetaClienteService
    {
        ITarjetaClienteRepository _TarjetaClienteRepository;
        public AdministrarTarjetaClienteService(ITarjetaClienteRepository TarjetaClienteRepository)
        {
            _TarjetaClienteRepository = TarjetaClienteRepository;
        }

        public TarjetaCliente Actualizar(TarjetaCliente entity)
        {
            return _TarjetaClienteRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _TarjetaClienteRepository.Eliminar(id);
        }

        public TarjetaCliente Guardar(TarjetaCliente entity)
        {
            return _TarjetaClienteRepository.Guardar(entity);
        }

        public TarjetaCliente ObtenerPorId(Guid id)
        {
            return _TarjetaClienteRepository.ObtenerPorId(id);
        }

        public IList<TarjetaCliente> ObtenerTodo()
        {
            return _TarjetaClienteRepository.ObtenerTodo();
        }
    }
}
