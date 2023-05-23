using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Core.DataAccess.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Linq.Expressions;

namespace MotorAsinBasketRobot.Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<T, TContext> : IEntityRepository<T> where TContext : DbContext, new() where T : class, IBaseEntity
    {

        public async Task<T> GetAsync(object id, Expression<Func<T, bool>> predicate = null)
        {
            using (TContext context = new TContext())
            {
                if (predicate != null)
                {
                    T entity = await context.Set<T>().FirstOrDefaultAsync(predicate);
                    if (entity == null)
                        throw new Exception("Veri bulunamadı! Id = " + id.ToString());
                    return entity;
                }
                return await context.Set<T>().FirstOrDefaultAsync();
            }
        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] property)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (predicate != null)
                    return await query.FirstOrDefaultAsync(predicate);
                return await query.FirstOrDefaultAsync();
            }
        }
        public async Task<T> GetAsync(object id, Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] property)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (predicate != null)
                {
                    T entity = await query.FirstOrDefaultAsync(predicate);
                    if (entity == null)
                        throw new Exception("Veri bulunamadı! Id = " + id.ToString());
                    return entity;
                }
                return await query.FirstOrDefaultAsync();
            }
        }
        public async Task<T> CreateAsync(T entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<T> UpdateAsync(T entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<T> DeleteAsync(T entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
                return entity;
            }
        }
        public async Task<List<T>> GetAllListAsync<TKey>(Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (orderBy != null)
                    query = query.OrderBy(orderBy);
                return await query.ToListAsync();
            }
        }
        public async Task<List<T>> GetAllPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (orderBy != null)
                    query = query.OrderBy(orderBy);
                return await query.Skip(skipCount).Take(maxResultCount).ToListAsync();
            }
        }
        public async Task<List<T>> GetListAsync<TKey>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property)
        {   
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (predicate != null)
                    query = query.Where(predicate);
                if (orderBy != null)
                    query = query.OrderBy(orderBy);
                return await query.ToListAsync();
            }
        }
        public async Task<List<T>> GetListAsync<TKey>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> orderBy = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                if (predicate != null)
                    query = query.Where(predicate);
                if (orderBy != null)
                    query = query.OrderBy(orderBy);
                return await query.ToListAsync();
            }
        }
        public async Task<List<T>> GetLastListAsync<TKey>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (predicate != null)
                    query = query.Where(predicate);
                if (orderBy != null)
                    query = query.OrderByDescending(orderBy);
                return await query.ToListAsync();
            }
        }
        public async Task<List<T>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property)
        {

            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (predicate != null)
                    query = query.Where(predicate);
                if (orderBy != null)
                    query = query.OrderBy(orderBy);
                return await query.Skip(skipCount).Take(maxResultCount).ToListAsync();
            }
        }
        public async Task<List<T>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> orderBy = null)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                if (predicate != null)
                    query = query.Where(predicate);
                if (orderBy != null)
                    query = query.OrderBy(orderBy);
                return await query.Skip(skipCount).Take(maxResultCount).ToListAsync();
            }
        }
        public async Task<List<T>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<T, bool>> predicate = null, Expression<Func<T, TKey>> orderBy = null, params Expression<Func<T, object>>[] property)
        {
            using (TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                for (int i = 0; i < property.Length; i++)
                    query = query.Include(property[i]);
                if (predicate != null)
                    query = query.Where(predicate);
                if (orderBy != null)
                    query = query.OrderByDescending(orderBy);
                return await query.Skip(skipCount).Take(maxResultCount).ToListAsync();
            }
        }
        public async Task<string> GetCodeAsync(Expression<Func<T, string>> propertySelector, Expression<Func<T, bool>> predicate = null)
        {
            static string CreateNewCode(string code)
            {
                var number = "";
                foreach (var character in code)
                {
                    if (char.IsDigit(character))
                        number += character;
                    else
                        number = "";
                }
                var newNumber = number == "" ? "1" : (long.Parse(number) + 1).ToString();
                var difference = code.Length - newNumber.Length;
                if (difference < 0)
                    difference = 0;
                var newCode = code.Substring(0, difference);
                newCode += newNumber;
                return newCode;
            }
            using (TContext context = new TContext())
            {
                IQueryable<T> dbSet = context.Set<T>();
                var maxCode = predicate == null ?
                    await dbSet.MaxAsync(propertySelector) :
                    await dbSet.Where(predicate).MaxAsync(propertySelector);
                return maxCode == null ? "0000000000000001" : CreateNewCode(maxCode);
            }
        }
        public async Task<IList<T>> FromSqlRawAsync(string sql, params object[] parameters)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<T>().FromSqlRaw(sql, parameters).ToListAsync();
            }
        }
        public async Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate = null)
        {
            using (TContext context = new TContext())
            {
                return predicate == null ? await context.Set<T>().AnyAsync() : await context.Set<T>().AnyAsync(predicate);
            }
        }
        public async Task<int> CountAsync(Expression<Func<T, bool>> prediacate = null)
        {
            using (TContext context = new TContext())
            {
                return prediacate == null ? await context.Set<T>().CountAsync() : await context.Set<T>().Where(prediacate).CountAsync();
            }
        }

        public async Task<IDataResult<List<T>>> TestGetListAsync()
        {
            using(TContext context = new TContext())
            {
                IQueryable<T> query = context.Set<T>();
                return new  SuccessDataResult<List<T>>(await query.ToListAsync());
            }
        }
    }

}
