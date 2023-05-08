using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.BasketStatus
{
    public class UpdateBasketStatus
    {
        public string? ProductCode { get; set; }
        public string? CustomerCode { get; set; }
    }
}
