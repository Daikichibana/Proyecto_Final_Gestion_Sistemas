using CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES;
using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using CAPAS.CAPA.TECNICA.CLIENTES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.CLIENTES.SERVICIOS
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
