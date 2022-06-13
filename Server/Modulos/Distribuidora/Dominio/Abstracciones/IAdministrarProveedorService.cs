using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarProveedorService
    {
        void Eliminar(Guid id);
        IList<EmpresaProveedor> ObtenerTodo();
        EmpresaProveedor ObtenerPorId(Guid id);
        EmpresaProveedor Guardar(EmpresaProveedor entity);
        EmpresaProveedor Actualizar(EmpresaProveedor entity);
    }
}
