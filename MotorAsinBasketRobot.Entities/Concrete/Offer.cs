using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class Offer : BaseEntity
    {
        public string? CustomerCode { get; set; }
        public string? ProductCode { get; set; }
        public int? Quantity { get; set; }

    }
}
