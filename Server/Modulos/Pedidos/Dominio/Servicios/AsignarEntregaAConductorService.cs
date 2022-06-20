using AutoMapper;
using Compartido.Dto.Pedidos;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;
using System;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class AsignarEntregaAConductorService : IAsignarEntregaAConductorService
    {
        UnidadDeTrabajo _unidad;
        IMapper _mapper;
        public AsignarEntregaAConductorService(IMapper mapper, BaseDatosContext contexto) {
            _unidad = new UnidadDeTrabajo(contexto);
            _mapper = mapper;
        }

        public void AsignarEntregaAconductor(AsignacionEntregaConductorDTO asignacion) {
            Guid IdConductorVehiculo = asignacion.IdConductorVehiculo;
            Guid IdPedido = asignacion.IdPedido;
            Pedido pedido = _unidad.pedidoRepository.ObtenerPorId(IdPedido);
            pedido.ConductorAsignadoId = IdConductorVehiculo;
            pedido.EstadoEnvio = "Pedido Asignado";
            pedido.OrdenPedido = null;
            pedido.ConductorAsignado = null;
            _unidad.pedidoRepository.Actualizar(pedido);
            _unidad.Complete();
        }
    }
}
