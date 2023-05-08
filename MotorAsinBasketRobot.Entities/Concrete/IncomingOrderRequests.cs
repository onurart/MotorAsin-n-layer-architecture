using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class IncomingOrderRequests : BaseEntity
    {
        public string Title { get; set; }
        public string Desction { get; set; }
        public DateTime RequestsTimes { get; set; }
    }
}
