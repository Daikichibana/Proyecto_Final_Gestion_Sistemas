using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarDistribuidoraService
    {
        void EliminarDistribuidora(Guid id);
        IList<EmpresaDistribuidora> ObtenerTodoDistribuidora();
        EmpresaDistribuidora ObtenerPorIdDistribuidora(Guid id);
        EmpresaDistribuidora GuardarDistribuidora(EmpresaDistribuidora entity);
        EmpresaDistribuidora ActualizarDistribuidora(EmpresaDistribuidora entity);
    }
}
