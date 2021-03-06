using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto_Final_Gestion_Sistemas.Server.Modulos;

namespace Proyecto_Final_Gestion_Sistemas.Server.Persistencia
{
    public interface IRepository<T>
    {
        void Eliminar(Guid id);
        IList<T> ObtenerTodo();
        T ObtenerPorId(Guid? id);
        T Guardar(T entity);
        T Actualizar(T entity);
        void GuardarCambios();

    }

    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        DbSet<T> _tabla;

        protected BaseDatosContext _ctx;

        public Repository(BaseDatosContext ctx)
        {
            _ctx = ctx;
            _tabla = ctx.Set<T>();
        }

        public void Eliminar(Guid id)
        {
            var tmp = _tabla.Find(id);
            if (tmp != null)
            {
                _tabla.Remove(tmp);
                //_ctx.SaveChanges();
            }
        }

        public IList<T> ObtenerTodo()
        {
            return _tabla.AsNoTracking().ToList();
        }

        public T ObtenerPorId(Guid? id)
        {
            return _tabla.Find(id);
        }

        public T Guardar(T entity)
        {
            _tabla.Add(entity);
            //_ctx.SaveChanges();
            return entity;
        }

        public T Actualizar(T entity)
        {
            _tabla.Update(entity);
            //_ctx.SaveChanges();
            return entity;
        }

        public void GuardarCambios()
        {
            _ctx.SaveChanges();
        }
    }
}
