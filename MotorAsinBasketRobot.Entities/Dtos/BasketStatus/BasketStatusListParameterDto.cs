using MotorAsinBasketRobot.Core.Entities.Abstract;
using MotorAsinBasketRobot.Core.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.BasketStatus
{
    public class BasketStatusListParameterDto : PageListParameterDto, IStatu, IBaseDto
    {
        public bool Statu { get; set; }
        public string? Code { get; set; }
        public bool? IsActive { get; set; }
    }
}
