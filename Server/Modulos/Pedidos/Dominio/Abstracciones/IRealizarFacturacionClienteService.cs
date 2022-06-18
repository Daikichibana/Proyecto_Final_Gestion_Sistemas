using Compartido.Dto.Pedidos.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IRealizarFacturacionClienteService
    {
        void EliminarFactura(Guid id);
        IList<FacturaDTO> ObtenerTodoFactura();
        FacturaDTO ObtenerPorIdFactura(Guid id);
        void ConfirmarPago(Guid IdPedido);
    }
}
