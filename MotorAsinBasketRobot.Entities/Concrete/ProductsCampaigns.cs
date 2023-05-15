using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class ProductsCampaigns: BaseEntity
    {
        public int? ProductReferance { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductGroup { get; set; }
        public double? MinOrder { get; set; }
    }
}
