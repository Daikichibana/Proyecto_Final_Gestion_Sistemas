using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPAS.CAPA.DOMINIO.USUARIOS.ABSTRACCIONES
{
    public interface IAdministrarRolService
    {
        void Eliminar(Guid id);
        IList<Rol> ObtenerTodo();
        Rol ObtenerPorId(Guid id);
        Rol Guardar(Rol entity);
        Rol Actualizar(Rol entity);
    }
}
