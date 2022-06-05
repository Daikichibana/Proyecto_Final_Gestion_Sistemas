using CAPAS.CAPA.DOMINIO.CLIENTES.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES
{
    public interface IAdministrarTarjetaClienteService
    {
        void Eliminar(Guid id);
        IList<TarjetaCliente> ObtenerTodo();
        TarjetaCliente ObtenerPorId(int id);
        TarjetaCliente Guardar(TarjetaCliente entity);
        TarjetaCliente Actualizar(TarjetaCliente entity);
    }
}
