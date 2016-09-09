using IRepositoryUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace CRepositoryUnitOfWork
{
    public class Repository : IRepository, IDisposable
    {
        //Context of EntityFrameWork
        protected DbContext Context;

        //Cosntructor for Repository
        public Repository(DbContext Context, bool autoDetectChangesEnabled = false, bool proxyCreationEnabled = false)
        {
            this.Context = Context;
            this.Context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
            this.Context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
        }

        //Allow be override and return a int number
        protected virtual int TrySaveChanges()
        {
            return Context.SaveChanges();
        }

        public TEntity Create<TEntity>(TEntity newEntity) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = Context.Set<TEntity>().Add(newEntity);
                TrySaveChanges();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public bool Delete<TEntity>(TEntity deleteEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                //Attach to the context (Los adjunta al contexto, pero aun no estan marcados para borrar)
                Context.Set<TEntity>().Attach(deleteEntity);
                //Marks the entity to be deleted
                Context.Set<TEntity>().Remove(deleteEntity);
                //True if TrySaveChanges() return a number > 0
                Result = TrySaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public IEnumerable<TEntity> FindEntities<TEntity>(Expression<Func<TEntity, bool>> criteriaLambda) where TEntity : class
        {
            List<TEntity> Result = null;
            try
            {
                Result = Context.Set<TEntity>().Where<TEntity>(criteriaLambda).ToList<TEntity>();
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteriaLambda) where TEntity : class
        {
            TEntity Result = null;
            try
            {
                Result = Context.Set<TEntity>().FirstOrDefault<TEntity>(criteriaLambda);
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public bool Update<TEntity>(TEntity updateEntity) where TEntity : class
        {
            bool Result = false;
            try
            {
                //Attach to the context (Los adjunta al contexto, pero aun no estan marcados para modificar)
                Context.Set<TEntity>().Attach(updateEntity);
                //Entry to the state of the entity to Mofified state
                Context.Entry<TEntity>(updateEntity).State = EntityState.Modified;
                //True if TrySaveChanges() return a number > 0
                Result = TrySaveChanges() > 0;
            }
            catch (Exception e)
            {
                throw (e);
            }
            return Result;
        }

        public void Dispose()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}
