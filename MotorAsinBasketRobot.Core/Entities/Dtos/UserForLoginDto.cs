using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.Entities.Dtos
{
    public class UserForLoginDto : IBaseDto
    {
        public String Email { get; set; }
        public String Password { get; set; }
    }
}
