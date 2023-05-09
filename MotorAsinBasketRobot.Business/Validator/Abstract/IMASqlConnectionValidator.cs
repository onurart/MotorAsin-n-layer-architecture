using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Validator.Abstract
{
    public interface IMASqlConnectionValidator
    {
        Task CheckCreateAsync(string code);
    }
}
