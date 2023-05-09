using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.Customer
{
    public class ListCustomerDtos : IDto, IStatu
    {
        public int? CustomerReferance { get; set; }
        public string? CustomerCode { get; set; }
    }
}
