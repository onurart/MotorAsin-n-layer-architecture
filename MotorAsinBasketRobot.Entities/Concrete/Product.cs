using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public int? ProductReferance { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public string? ProductGroup1 { get; set; }
        public string? ProductGroup2 { get; set; }
        public string? ProductGroup3 { get; set; }
        public string? ProductGroup4 { get; set; }
        public int? DisplayProduct { get; set; }
        public int? SoldOfferrd { get; set; }
        public int? IsSoldOrdered { get; set; }
        public int? StandbyTime { get; set; }

    }
}
