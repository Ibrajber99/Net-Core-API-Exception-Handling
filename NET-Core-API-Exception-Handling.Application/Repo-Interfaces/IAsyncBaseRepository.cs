using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NET_Core_API_Exception_Handling.Application.Repo_Interfaces
{
    public interface IAsyncBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> ListAllAsync();

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
