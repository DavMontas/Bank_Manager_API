using Bank.Core.Application.Interfaces.Repositories;
using Bank.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Bank.Infrastructure.Persistance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T>  where T : class
    {
        private readonly AppDbContext _db;

        public GenericRepository(AppDbContext db)
        {
            _db = db;
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await _db.Set<T>().ToListAsync();
        }
        public virtual async Task<List<T>> GetAllWithIncludeAsync(List<string> props)
        {
            var query = _db.Set<T>().AsQueryable();

            foreach (string prop in props)
            {
                query = query.Include(prop);
            }

            return await query.ToListAsync();
        }
        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public virtual async Task<T> AddAsync(T T)
        {
            await _db.Set<T>().AddAsync(T);
            await _db.SaveChangesAsync();
            return T;
        }
        public virtual async Task UpdateAsync(T T, int id)
        {
            T entry = await _db.Set<T>().FindAsync(id);
            _db.Entry(entry).CurrentValues.SetValues(T);
            await _db.SaveChangesAsync();
        }
        public virtual async Task DeleteAsync(T T)
        {
            _db.Set<T>().Remove(T);
            await _db.SaveChangesAsync();

        }
        public virtual async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
