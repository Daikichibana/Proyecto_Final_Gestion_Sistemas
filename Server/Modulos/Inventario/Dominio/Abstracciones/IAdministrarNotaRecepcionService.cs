using Compartido.Dto.Inventario.General;
using System;
using System.Collections.Generic;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Inventario.Dominio.Abstracciones
{
    public interface IAdministrarNotaRecepcionService
    {
        void EliminarNotaRecepcion(Guid id);
        IList<NotaRecepcionDTO> ObtenerTodoNotaRecepcion();
        NotaRecepcionDTO ObtenerPorIdNotaRecepcion(Guid id);
        NotaRecepcionDTO GuardarNotaRecepcion(NotaRecepcionDTO entity);
        NotaRecepcionDTO ActualizarNotaRecepcion(NotaRecepcionDTO entity);
    }
}
