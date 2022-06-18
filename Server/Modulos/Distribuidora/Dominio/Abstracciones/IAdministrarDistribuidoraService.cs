using System;
using System.Collections.Generic;
using Compartido.Dto.Distribuidora.General;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface IAdministrarDistribuidoraService
    {
        void EliminarDistribuidora(Guid id);
        IList<EmpresaDistribuidoraDTO> ObtenerTodoDistribuidora();
        EmpresaDistribuidoraDTO ObtenerPorIdDistribuidora(Guid id);
        EmpresaDistribuidoraDTO GuardarDistribuidora(EmpresaDistribuidoraDTO entity);
        EmpresaDistribuidoraDTO ActualizarDistribuidora(EmpresaDistribuidoraDTO entity);
    }
}
