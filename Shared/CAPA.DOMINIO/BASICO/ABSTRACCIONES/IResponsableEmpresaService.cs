using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES
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
