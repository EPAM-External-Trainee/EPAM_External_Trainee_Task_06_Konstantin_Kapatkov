using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.DAO.Interfaces
{
    /// <summary>Interface describes CRUD functionality</summary>
    /// <typeparam name="T">ORM model</typeparam>
    public interface IDao<T>
    {
        /// <summary>Trying to add to DB</summary>
        /// <param name="data">Data to add</param>
        /// <returns>Result of the operation</returns>
        Task<bool> TryCreateAsync(T data);

        /// <summary>Trying to read from DB</summary>
        /// <param name="id">Model class object id</param>
        /// <returns>Model class object</returns>
        Task<T> TryReadAsync(int id);

        /// <summary>Trying to update model class object in DB</summary>
        /// <param name="data">Model class object to update</param>
        /// <returns>Result of the operation</returns>
        Task<bool> TryUpdateAsync(T data);

        /// <summary>Trying to delete model class object from DB</summary>
        /// <param name="id">Model class object id</param>
        /// <returns>Result of the operation</returns>
        Task<bool> TryDeleteAsync(int id);

        /// <summary>Trying to read all model class objects from DB</summary>
        /// <returns>Model class objects</returns>
        Task<IEnumerable<T>> TryReadAllAsync();
    }
}