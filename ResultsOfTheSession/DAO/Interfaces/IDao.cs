using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResultsOfTheSession.DAO.Interfaces
{
    public interface IDao<T>
    {
        Task<bool> CreateAsync(T data);

        Task<T> ReadAsync(int id);

        Task<bool> UpdateAsync(T data);

        Task<bool> DeleteAsync(int id);

        Task<IEnumerable<T>> ReadAllAsync();
    }
}