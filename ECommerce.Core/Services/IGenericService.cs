
using System.Linq.Expressions;


namespace ECommerce.Core.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<int> GetCountAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T, bool>> expression);

        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);

        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Update(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);
    }
}
