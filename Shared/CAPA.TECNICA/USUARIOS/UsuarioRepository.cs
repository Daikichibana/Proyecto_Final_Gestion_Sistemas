using CAPAS.CAPA.DOMINIO.USUARIOS.ENTIDADES;
using CAPAS.CAPA.TECNICA.PERSISTENCIA;
using System.Linq;

namespace CAPAS.CAPA.TECNICA.USUARIOS
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Usuario ObtenerUsuarioPorNombre(string nombre);
    }
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(BaseDatosContext ctx) : base(ctx)
        {
        }

        public Usuario ObtenerUsuarioPorNombre(string nombre)
        {
            return ObtenerTodo().Where(t => t.NombreUsuario.Equals(nombre)).FirstOrDefault();
        }
    }
}
