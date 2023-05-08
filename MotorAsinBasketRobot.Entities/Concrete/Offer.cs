using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class Offer : BaseEntity
    {
        public int? ProductReferance { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductGroup1 { get; set; }
        public string? ProductGroup2 { get; set; }
        public string? ProductGroup3 { get; set; }
        public string? ProductGroup4 { get; set; }
    }
}
