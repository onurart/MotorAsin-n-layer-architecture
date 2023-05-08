using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IBaseService<T> where T : class
    {
        Task<IDataResult<T>> Get(int id);
        Task<IDataResult<T>> Create(T entity);
        Task<IDataResult<T>> Update(T entity);
        Task<IDataResult<T>> Delete(T entity);
    }
}
