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

        public Factura Actualizar(Factura entity)
        {
            return _facturaRepository.Actualizar(entity);
        }

        public void Eliminar(Guid id)
        {
            _facturaRepository.Eliminar(id);
        }

        public Factura Guardar(Factura entity)
        {
            return _facturaRepository.Guardar(entity);
        }

        public Factura ObtenerPorId(Guid id)
        {
            return _facturaRepository.ObtenerPorId(id);
        }

        public IList<Factura> ObtenerTodo()
        {
            return _facturaRepository.ObtenerTodo();
        }
    }
}
