using Domain.Models;

namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : ClientEntity
    {
        Task<T> CreateAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}