using MantuPractice.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace MantuPractice.Infrastructure
{
    public class CrudRepository<T> : ICrudRepository<T> where T : class
    {
        private readonly BdeComDbContext _context;

        public CrudRepository(BdeComDbContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }

}