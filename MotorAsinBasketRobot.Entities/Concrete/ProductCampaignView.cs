using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class ProductCampaignView
    {
        [Key]
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public int Year { get; set; }
        public int Count { get; set; }
    }
}
