using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarProveedorService
    {
        void EliminarProveedor(Guid id);
        IList<EmpresaProveedor> ObtenerTodoProveedor();
        EmpresaProveedor ObtenerPorIdProveedor(Guid id);
        EmpresaProveedor GuardarProveedor(EmpresaProveedor entity);
        EmpresaProveedor ActualizarProveedor(EmpresaProveedor entity);
    }
}
