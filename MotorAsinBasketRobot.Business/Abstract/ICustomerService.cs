using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.BasketStatus;
using MotorAsinBasketRobot.Entities.Dtos.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public  interface ICustomerService:IBaseService<Customer>
    {
        Task<IDataResult<IList<Customer>>> GetList(CustomerListPramertDto parameterDto);
               Task<IDataResult<string>> GetCode(CustomerCodeParameterDto parameterDto);

    }
}
