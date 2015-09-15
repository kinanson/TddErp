using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddErp.Model.Models;

namespace TddErp.Service.Interface
{
   public interface IEntityService<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        T GetById(int Id);
    }

    public abstract class EntityService<T> : IEntityService<T> where T :class
    {
        protected IContext db;
        protected DbSet<T> dbset;

        public EntityService(IContext db)
        {
            this.db = db;
            dbset = db.Set<T>();
        }

        public virtual void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            dbset.Add(entity);            
            db.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            dbset.Remove(entity);
            db.SaveChanges();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.AsEnumerable<T>();
        }

        public T GetById(int Id)
        {
            return dbset.Find(Id);
        }
    }
}
