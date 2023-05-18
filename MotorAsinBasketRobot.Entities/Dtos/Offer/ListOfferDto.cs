using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.Offer
{
    public class ListOfferDto : IBaseDto, IStatu
    {
        public string? CustomerCode { get; set; }
        public string? ProductCode { get; set; }
        public int? Quantity { get; set; }
    }
}
