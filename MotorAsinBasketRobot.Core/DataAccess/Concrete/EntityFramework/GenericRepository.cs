using Microsoft.EntityFrameworkCore;
using MotorAsinBasketRobot.Core.DataAccess.Abstract;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.DataAccess.Concrete.EntityFramework
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //protected readonly AppDbContext _dbContext;
        //private readonly DbSet<T> _dbSet;
        //public GenericRepository(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //    _dbSet = dbContext.Set<T>();
        //}
        public async Task<IDataResult<List<T>>> GetListAsync()
        {
            return null;/* new SuccessDataResult<List<T>>(await _dbSet.ToListAsync())*/;
        }
    }
}
