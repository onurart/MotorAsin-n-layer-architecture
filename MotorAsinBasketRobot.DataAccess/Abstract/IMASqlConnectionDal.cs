using MotorAsinBasketRobot.Core.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.DataAccess.Abstract
{
    public interface IMASqlConnectionDal:IEntityRepository<MASqlConnection>
    {

        Task UpdateConnectionString(MASqlConnection MASqlConnection);
    }
}
