using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class AdministrarPedidoService : IAdministrarPedidoService
    {
        IPedidoRepository _pedidoRepository;
        public AdministrarPedidoService(IPedidoRepository pedidoRepository) 
        {
            _pedidoRepository = pedidoRepository;
        }

        public Pedido Actualizar(Pedido entity)
        {
            return _pedidoRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _pedidoRepository.Eliminar(id);
        }

        public Pedido Guardar(Pedido entity)
        {
            return _pedidoRepository.Guardar(entity);
        }

        public Pedido ObtenerPorId(Guid id)
        {
            return _pedidoRepository.ObtenerPorId(id);
        }

        public IList<Pedido> ObtenerTodo()
        {
            return _pedidoRepository.ObtenerTodo(); 
        }
    }
}
