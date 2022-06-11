using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarDistribuidoraService
    {
        void Eliminar(Guid id);
        IList<EmpresaDistribuidora> ObtenerTodo();
        EmpresaDistribuidora ObtenerPorId(Guid id);
        EmpresaDistribuidora Guardar(EmpresaDistribuidora entity);
        EmpresaDistribuidora Actualizar(EmpresaDistribuidora entity);
    }
}
