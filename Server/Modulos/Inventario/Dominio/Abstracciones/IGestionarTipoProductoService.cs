using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Compartido.Dto.Inventario.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IGestionarTipoProductoService
    {
        void EliminarTipoProducto(IList<Guid> id);
        IList<TipoProductoDTO> ObtenerTodoTipoProducto();
        TipoProductoDTO ObtenerPorIdTipoProducto(Guid id);
        IList<TipoProductoDTO> GuardarTipoProducto(IList<TipoProductoDTO> entity);
        IList<TipoProductoDTO> ActualizarTipoProducto(IList<TipoProductoDTO> entity);
    }
}
