//--------------------  COPYRIGHT 2023 TnT Holdings, LLC --------------------//

#region Includes

// .NET Libraries
using System.Linq.Expressions;

#endregion

namespace IQ.Infrastructure.Interfaces
{
    /// <summary>
    /// Defines various methods for working with data in the system.
    /// </summary>
    /// <typeparam name="T">The object type.</typeparam>
    /// <typeparam name="K">The object types unique id type.</typeparam>
    public interface IRepository<T,K> where T : class
    {
        /// <summary>
        /// Finds an item by its unique id in the data store.
        /// </summary>
        /// <param name="idx">The unique id of the item in the data store.</param>
        /// <param name="includeProperties">
        /// An expression of additional properties to eager load.
        /// Ex:
        ///     x => x.SomeCollection, x => x.AnotherCollection
        /// </param>
        /// <returns>The requested item when found, otherwise null.</returns>
        T FindById(K idx, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Returns an IQueryable of all items of type T.
        /// </summary>
        /// <param name="includeProperties">
        /// An expression of additional properties to eager load.
        /// Ex:
        ///     x => x.SomeCollection, x => x.AnotherCollection
        /// </param>
        /// <returns>An IQueryable of the requested type.</returns>
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Returns an IEnumerable of items of type T.
        /// </summary>
        /// <param name="predicate">
        /// A predicate to limit the items being returned.
        /// Ex:
        ///     
        /// </param>
        /// <param name="includeProperties">
        /// An expression of additional properties to eager load.
        /// Ex:
        ///     x => x.SomeCollection, x => x.AnotherCollection
        /// </param>
        /// <returns></returns>
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Adds an entity to the underlying collection.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Removes an entity from the underlying collection.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        void Remove(T entity);
        
        /// <summary>
        /// Removes an entity from the underlying collection.
        /// </summary>
        /// <param name="idx">The unique id of the entity to remove.</param>
        void Remove(K idx);
    }
}
