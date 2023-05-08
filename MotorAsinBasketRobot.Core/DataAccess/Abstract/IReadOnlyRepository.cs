using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.DataAccess.Abstract
{
    public interface IReadOnlyRepository<T> : IRepository where T : class, IBaseEntity
    {
        Task<bool> GetAnyAsync(Expression<Func<T, bool>> predicate = null);
        Task<int> CountAsync(Expression<Func<T, bool>> prediacate = null);

    }
}
