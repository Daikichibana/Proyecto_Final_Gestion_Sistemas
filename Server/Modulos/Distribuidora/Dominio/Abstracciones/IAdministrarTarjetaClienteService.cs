using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarTarjetaClienteService
    {
        void EliminarTarjetaCliente(Guid id);
        IList<TarjetaCliente> ObtenerTodoTarjetaCliente();
        TarjetaCliente ObtenerPorIdTarjetaCliente(Guid id);
        TarjetaCliente GuardarTarjetaCliente(TarjetaCliente entity);
        TarjetaCliente ActualizarTarjetaCliente(TarjetaCliente entity);
    }
}
