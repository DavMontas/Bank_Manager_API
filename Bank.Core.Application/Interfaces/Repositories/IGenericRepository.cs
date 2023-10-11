using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithIncludeAsync(List<string> props);
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T T);
        Task UpdateAsync(T? T, int id);
        Task DeleteAsync(T T);
        Task SaveChanges();
    }
}
