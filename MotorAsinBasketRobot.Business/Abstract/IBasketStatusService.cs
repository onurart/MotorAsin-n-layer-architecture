using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IBasketStatusService:IBaseService<BasketStatus>
    {
        Task<IDataResult<IList<BasketStatus>>> GetList(BasketStatusListParameterDto parameterDto);
        //Task<IDataResult<IList<BasketStatus>>> GetByIdList(BasketStatusListParameterDto parameterDto);
        //Task<IDataResult<PagedResult<BasketStatus>>> GetPagedList(CategoryListParameterDto parameterDto);
        //Task<IDataResult<PagedResult<BasketStatus>>> GetByIdPagedList(CategoryListParameterDto parameterDto);
    }
}
