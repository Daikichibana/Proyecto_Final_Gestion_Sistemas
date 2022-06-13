using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones
{
    public interface IRealizarFacturacionClienteService
    {
        void Eliminar(Guid id);
        IList<Factura> ObtenerTodo();
        Factura ObtenerPorId(Guid id);
        Factura Guardar(Factura entity);
        Factura Actualizar(Factura entity);
    }
}
