using MotorAsinBasketRobot.Entities.Concrete;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Validator.Abstract
{
    public interface ISpeCodeValidator
    {
        Task CheckCreateAsync(string code);
        Task CheckUpdateAsync(int id, string code, SpeCode entity);
        Task CheckDeleteAsync(int id);
    }
}
