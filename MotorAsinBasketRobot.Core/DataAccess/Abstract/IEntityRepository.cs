using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Core.Entities.Abstract;
using System.Linq.Expressions;

namespace MotorAsinBasketRobot.Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> : IReadOnlyRepository<T>, IRepository where T : class, IBaseEntity
    {
        Task<T> GetAsync(object id, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] property);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] property);
        Task<T> GetAsync(object id, Expression<Func<T, bool>> predicate = null);

        Task<List<T>> GetAllListAsync<TKey>(Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property);
        Task<List<T>> GetAllPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property);

        Task<List<T>> GetListAsync<TKey>(Expression<Func<T, bool>> predicate = null,
                    Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property);
        Task<List<T>> GetListAsync<TKey>(Expression<Func<T, bool>> predicate = null,
               Expression<Func<T, TKey>> orderBy = null);
        Task<List<T>> GetLastListAsync<TKey>(
                Expression<Func<T, bool>> predicate = null,
                Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property);

        Task<List<T>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,
                    Expression<Func<T, bool>> predicate = null,
                    Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property);

        Task<List<T>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount,
                   Expression<Func<T, bool>> predicate = null,
                   Expression<Func<T, TKey>> orderBy = null);
        Task<List<T>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount,
                   Expression<Func<T, bool>> predicate = null,
                   Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property);

        Task<string> GetCodeAsync(Expression<Func<T, string>> propertySelector, Expression<Func<T, bool>> predicate = null);
        Task<IList<T>> FromSqlRawAsync(string sql, params object[] parameters);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IDataResult<List<T>>> TestGetListAsync();
    }
}
