using Domain.Interfaces;
using Domain.Models;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : ClientEntity
    {
        protected ApplicationDbContext _context;
        private DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = _dbSet;
            return await query.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            IQueryable<T> query = _dbSet;
            return await query.SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            _dbSet.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}