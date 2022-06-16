using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Abstracciones;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Tecnica;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Pedidos.Dominio.Servicios
{
    public class RealizarFacturacionClienteService : IRealizarFacturacionClienteService
    {
        IFacturaRepository _facturaRepository;

        public RealizarFacturacionClienteService(IFacturaRepository facturaRepository)
        {
            this._facturaRepository = facturaRepository;
        }

        public Factura ActualizarFactura(Factura entity)
        {
            return _facturaRepository.Actualizar(entity);
        }

        public void EliminarFactura(Guid id)
        {
            _facturaRepository.Eliminar(id);
        }

        public Factura GuardarFactura(Factura entity)
        {
            return _facturaRepository.Guardar(entity);
        }

        public Factura ObtenerPorIdFactura(Guid id)
        {
            return _facturaRepository.ObtenerPorId(id);
        }

        public IList<Factura> ObtenerTodoFactura()
        {
            return _facturaRepository.ObtenerTodo();
        }
    }
}
