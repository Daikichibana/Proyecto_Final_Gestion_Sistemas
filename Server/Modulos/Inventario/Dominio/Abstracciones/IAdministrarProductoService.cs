using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IAdministrarProductoService
    {
        void Eliminar(Guid id);
        IList<Producto> ObtenerTodo();
        Producto ObtenerPorId(Guid id);
        Producto Guardar(Producto entity);
        Producto Actualizar(Producto entity);
    }
}
