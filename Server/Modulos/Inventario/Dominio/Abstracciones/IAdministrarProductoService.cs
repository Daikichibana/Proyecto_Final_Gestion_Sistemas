using System;
using System.Collections.Generic;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IAdministrarProductoService
    {
        void EliminarProducto(Guid id);
        IList<ProductoDTO> ObtenerTodoProducto();
        Producto ObtenerPorIdProducto(Guid id);
        Producto GuardarProducto(Producto entity);
        Producto ActualizarProducto(Producto entity);
    }
}
