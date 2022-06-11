using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Distribuidora.Dominio.Abstracciones
{
    public interface INITService
    {
        void Eliminar(Guid id);
        IList<NIT> ObtenerTodo();
        NIT ObtenerPorId(Guid id);
        NIT Guardar(NIT entity);
        NIT Actualizar(NIT entity);
    }
}
