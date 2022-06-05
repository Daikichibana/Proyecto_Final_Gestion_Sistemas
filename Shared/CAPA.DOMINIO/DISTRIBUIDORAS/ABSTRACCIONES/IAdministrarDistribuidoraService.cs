using CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ENTIDADES;
using System;
using System.Collections.Generic;

namespace CAPAS.CAPA.DOMINIO.DISTRIBUIDORAS.ABSTRACCIONES
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
