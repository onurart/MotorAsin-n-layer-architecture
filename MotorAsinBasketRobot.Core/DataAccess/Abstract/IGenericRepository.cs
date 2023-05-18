using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.DataAccess.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IDataResult<List<T>>> GetListAsync();

    }
}
