using MotorAsinBasketRobot.Core.DataAccess.Concrete.EntityFramework;
using MotorAsinBasketRobot.DataAccess.Abstract;
using MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework.Context;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, AppDbContext>, ICustomerDal
    {
    }
}
