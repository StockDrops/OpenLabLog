using OpenLabLog.Core.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLabLog.Core.Contracts.Services
{
    /// <summary>
    /// A generic repository service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryService<T> where T : IEntity
    {
        /// <summary>
        /// Gets an item. Returns null if not present.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetAsync(long id);
        /// <summary>
        /// Gets all items
        /// </summary>
        /// <returns></returns>
        Task<List<T>> GetAllAsync();
        /// <summary>
        /// Creates an item
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>Returns the created entity.</returns>
        Task<T> CreateAsync(T entity);
        /// <summary>
        /// Deletes an item.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteAsync(long id);
        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(T entity);
    }
}
