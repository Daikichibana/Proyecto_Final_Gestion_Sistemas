using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IRealizarFacturacionClienteService
    {
        void EliminarFactura(Guid id);
        IList<Factura> ObtenerTodoFactura();
        Factura ObtenerPorIdFactura(Guid id);
        Factura GuardarFactura(Factura entity);
        Factura ActualizarFactura(Factura entity);
    }
}
