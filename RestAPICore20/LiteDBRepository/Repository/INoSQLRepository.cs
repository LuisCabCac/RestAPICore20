using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace RestAPICore20.NoSQL.LiteDB.Repository
{
    public interface INoSQLRepository<T>
    {
        /// <summary>
        /// Adds the new entity in the repository.
        /// </summary>
        /// <param name="param">The entity to add.</param>
        /// <returns>The added entity including its new ObjectId.</returns>
        bool Save(T param);

        /// <summary>
        /// Adds the new entities in the repository.
        /// </summary>
        /// <param name="entities">The entities of type T.</param>
        void Save(IEnumerable<T> param);

        /// <summary>
        /// Upserts an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>The updated entity.</returns>
        T Update(T entity);

        /// <summary>
        /// Upserts the entities.
        /// </summary>
        /// <param name="entities">The entities to update.</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Returns the T by its given id.
        /// </summary>
        /// <param name="predicate">The value representing the ObjectId of the entity to retrieve.</param>
        /// <returns>The Entity T.</returns>
        T GetOne(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Deletes the entities matching the predicate.
        /// </summary>
        /// <param name="predicate">The expression.</param>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Deletes the entities matching the predicate.
        /// </summary>
        /// <param name="predicate">The expression.</param>
        IEnumerable<T> GetTop(Expression<Func<T, bool>> predicate, int top);

        /// <summary>
        /// Counts the total entities in the repository.
        /// </summary>
        /// <returns>Count of entities in the repository.</returns>
        long Count(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Checks if the entity exists for given predicate.
        /// </summary>
        /// <param name="Id">Id</param>
        /// <returns>True when an entity matching the predicate exists, false otherwise.</returns>
        bool Exists(Expression<Func<T, bool>> predicate);

    }
}
