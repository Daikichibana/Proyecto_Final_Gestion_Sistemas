using System.Linq;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Dominio.Entidades;
using Proyecto_Final_Gestion_Sistemas.Server.Persistencia;

namespace Proyecto_Final_Gestion_Sistemas.Server.Modulos.Personal.Tecnica
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
