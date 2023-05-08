using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class SpeCode : BaseEntity
    {
        public SpeCodeType SpeCodeType { get; set; }
        public SpeCodeCardType SpeCodeCardType { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public bool? Statu { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
