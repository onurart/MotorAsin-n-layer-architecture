using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.IncomingOrderRequests
{
    public class IncomingOrderRequestsPramertDto : IBaseDto, IStatu
    {
        public bool Statu { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }
}
