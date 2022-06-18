using System;
using System.Collections.Generic;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IAdministrarProductoService
    {
        void EliminarProducto(List<Guid> id);
        IList<ProductoDTO> ObtenerTodoProducto();
        ProductoDTO ObtenerPorIdProducto(Guid id);
        IList<ProductoDTO> ObtenerTodoProductoPorIdEmpresa(Guid IdEmpresa);
        IList<ProductoDTO> GuardarProducto(IList<ProductoDTO> entity);
        IList<ProductoDTO> ActualizarProducto(IList<ProductoDTO> entity);
    }
}
