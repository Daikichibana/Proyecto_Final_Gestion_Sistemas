﻿using System;
using System.Collections.Generic;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Abstracciones
{
    public interface IResponsableEmpresaService
    {
        void Eliminar(Guid id);
        IList<ResponsableEmpresa> ObtenerTodo();
        ResponsableEmpresa ObtenerPorId(Guid id);
        ResponsableEmpresa Guardar(ResponsableEmpresa entity);
        ResponsableEmpresa Actualizar(ResponsableEmpresa entity);
    }
}