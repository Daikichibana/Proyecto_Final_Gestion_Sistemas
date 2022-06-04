using CAPAS.CAPA.DOMINIO.BASICO.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.BASICO.ABSTRACCIONES
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
