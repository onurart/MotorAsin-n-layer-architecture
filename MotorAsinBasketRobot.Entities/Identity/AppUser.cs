using Microsoft.AspNetCore.Identity;
using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Identity
{
    public class AppUser: IdentityUser
    {
        public string? PhoneNumber { get; set; }
    }
}
