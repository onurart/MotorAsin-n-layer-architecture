using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Entities.Dtos.Customer;
using MotorAsinBasketRobot.Entities.Dtos.Documents;
using MotorAsinBasketRobot.Entities.Dtos.IncomingOrderRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IIncomingOrderRequestsService : IBaseService<IncomingOrderRequests>
    {
        Task<IDataResult<IList<IncomingOrderRequests>>> GetList(IncomingOrderRequestsPramertDto parameterDto);
    }
}
