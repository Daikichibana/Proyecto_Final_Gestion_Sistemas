using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IAdministrarPedidoService
    {
        void Eliminar(Guid id);
        IList<Pedido> ObtenerTodo();
        Pedido ObtenerPorId(Guid id);
        Pedido Guardar(Pedido entity);
        Pedido Actualizar(Pedido entity);
    }
}
