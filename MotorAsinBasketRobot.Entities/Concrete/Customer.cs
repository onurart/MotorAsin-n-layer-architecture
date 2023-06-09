using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class Customer : BaseEntity
    {
        public int? CustomerReferance { get; set; }
        public string? CustomerCode { get; set; }
        public string? CustomerName { get; set; }
    }
}
