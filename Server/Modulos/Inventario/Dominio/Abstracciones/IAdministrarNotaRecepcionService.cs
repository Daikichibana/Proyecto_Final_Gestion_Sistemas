using Compartido.Dto.Inventario.General;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IAdministrarNotaRecepcionService
    {
        IList<NotaRecepcionDTO> ObtenerTodoNotaRecepcion();
        NotaRecepcionDTO ObtenerPorIdNotaRecepcion(Guid id);
        IList<NotaRecepcionDTO> GuardarNotaRecepcion(IList<NotaRecepcionDTO> entity);
    }
}
