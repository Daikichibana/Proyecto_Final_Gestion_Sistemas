using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarProveedorService
    {
        void EliminarProveedor(Guid id);
        IList<EmpresaProveedorDTO> ObtenerTodoProveedor();
        EmpresaProveedorDTO ObtenerPorIdProveedor(Guid id);
        List<EmpresaProveedorDTO> GuardarProveedor(List<EmpresaProveedorDTO> entity);
        List<EmpresaProveedorDTO> ActualizarProveedor(List<EmpresaProveedorDTO> entity);
    }
}
