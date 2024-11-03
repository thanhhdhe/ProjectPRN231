using OnlineShop.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly OnlineShopDbContext _context;
        public GenericRepository(OnlineShopDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity ?? throw new InvalidOperationException($"Entity of type {typeof(T).Name} with ID {id} not found.");
        }


        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate) =>
            await _context.Set<T>().Where(predicate).ToListAsync();

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync(); 
        }


        public void Remove(T entity) => _context.Set<T>().Remove(entity);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
