using System.Linq.Expressions;

namespace IKEAProduct_API.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(string includeProperties = null);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string includeProperties = null);
        Task CreateAsync(T entity);
        Task SaveAsync();
    }
}
