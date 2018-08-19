using MyCinema.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCinema.Data.Repository.RepoBase
{
    /*
     * 
     * On utilise un RepositoryBase dans le cas ou l'on a beaucoup de tables simples
     * Le repo s'adapte à tout type grâce à la généricité de sa déclaration.
     * 
     */


    //On appelle une clause where dans une définition générique une contrainte
    public abstract class RepositoryBase<T> : IDisposable where T : class
    {
        #region -- DBContext --
        //protected car je veux que les enfants voient
        //le context
        protected MyCinemaContext Context { get; set; }
        #endregion

        #region -- Constructeur --
        public RepositoryBase()
        {
            Context = new MyCinemaContext();
        }
        #endregion

        #region -- Méthodes CRUD --

        public virtual IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public virtual T GetById(params object[] id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual void Add(T Entity)
        {
            Context.Set<T>().Add(Entity);
        }

        public virtual void Edit(T Entity)
        {
            var entry = Context.Entry<T>(Entity);
            if (entry.State == System.Data.Entity.EntityState.Detached)
            {
                Context.Set<T>().Attach(Entity);
                entry.State = System.Data.Entity.EntityState.Modified;
            }
        }

        public virtual void Delete(int id)
        {
            var entry = GetById(id);
            Context.Set<T>().Remove(entry);
        }

        public void Save()
        {
            try
            {
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error on save : {ex.Message}");
            }
        }

        #endregion

        #region -- Dispose --
        public void Dispose()
        {
            if (Context != null)
            {
                Save();
                Context = null;
            }
        }
        #endregion
    }
}
