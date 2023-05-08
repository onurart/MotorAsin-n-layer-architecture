using MotorAsinBasketRobot.Core.DataAccess.Abstract;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.DataAccess.Abstract
{
    public interface IIncomingOrderRequestsDal :IEntityRepository<IncomingOrderRequests>
    {
    }
}
