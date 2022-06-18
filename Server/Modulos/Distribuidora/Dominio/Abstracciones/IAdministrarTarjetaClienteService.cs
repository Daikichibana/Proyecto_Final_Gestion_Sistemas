using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarTarjetaClienteService
    {
        void EliminarTarjetaCliente(Guid id);
        IList<TarjetaClienteDTO> ObtenerTodoTarjetaCliente();
        TarjetaClienteDTO ObtenerPorIdTarjetaCliente(Guid id);
        IList<TarjetaClienteDTO>GuardarTarjetaCliente(IList<TarjetaClienteDTO>entity);
        IList<TarjetaClienteDTO> ActualizarTarjetaCliente(IList<TarjetaClienteDTO >entity);
    }
}
