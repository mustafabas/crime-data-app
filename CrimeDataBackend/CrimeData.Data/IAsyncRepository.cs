using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrimeData.Data
{
   public interface IAsyncRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        IQueryable<T> Table { get; }
        Task<List<T>> AddRangeAsync(List<T> entities);

    }
}
