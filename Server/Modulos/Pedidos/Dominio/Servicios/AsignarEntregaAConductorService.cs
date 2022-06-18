﻿using AutoMapper;
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

        public void AsignarEntregaAconductor(Guid IdConductorVehiculo, Guid IdPedido) {
            Pedido pedido = _unidad.pedidoRepository.ObtenerPorId(IdPedido);
            pedido.ConductorAsignadoId = IdConductorVehiculo;
            pedido.EstadoEnvio = "Pedido Asignado";

            _unidad.pedidoRepository.Actualizar(pedido);
            _unidad.Complete();
        }
    }
}
