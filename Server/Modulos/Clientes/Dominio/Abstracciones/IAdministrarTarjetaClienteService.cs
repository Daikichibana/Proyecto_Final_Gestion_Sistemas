using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Clientes.Dominio.Abstracciones
{
    public interface IAdministrarTarjetaClienteService
    {
        void Eliminar(Guid id);
        IList<TarjetaCliente> ObtenerTodo();
        TarjetaCliente ObtenerPorId(Guid id);
        TarjetaCliente Guardar(TarjetaCliente entity);
        TarjetaCliente Actualizar(TarjetaCliente entity);
    }
}
