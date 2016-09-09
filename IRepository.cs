using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositoryUnitOfWork
{
    /// <summary>
    /// Allow work with entities (No transaction)
    /// </summary>
    public interface IRepository : IDisposable
    {
        /// <summary>
        /// Create a new Entity for Insert in the database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="newEntity"></param>
        /// <returns>The entity created</returns>
        TEntity Create<TEntity>(TEntity newEntity) where TEntity: class;

        /// <summary>
        /// Update a entity for update in the database
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="updateEntity"></param>
        /// <returns>A bool value true if could update else false</returns>
        bool Update<TEntity>(TEntity updateEntity) where TEntity : class;

        /// <summary>
        /// Delete a entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="deleteEntity"></param>
        /// <returns>A bool value true if could delete else false</returns>
        bool Delete<TEntity>(TEntity deleteEntity) where TEntity : class;

        /// <summary>
        /// Get a entity if exist 
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteriaLambda"></param>
        /// <returns>A entity if exist</returns>
        TEntity FindEntity<TEntity>(Expression<Func<TEntity, bool>> criteriaLambda) where TEntity : class;

        /// <summary>
        /// Get a IEnumerable of entities
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="criteriaLambda"></param>
        /// <returns>List of entities</returns>
        IEnumerable<TEntity> FindEntities<TEntity>(Expression<Func<TEntity, bool>> criteriaLambda) where TEntity : class;
    }
}
