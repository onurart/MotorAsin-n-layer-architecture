using MotorAsinBasketRobot.Core.Entities.Abstract;
using MotorAsinBasketRobot.Core.Entities.Dtos;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.SpeCodeListParameterDto
{
    public class SpeCodeListParameterDto : PageListParameterDto, IBaseDto, IStatu
    {
        public SpeCodeType? SpeCodeType { get; set; }
        public SpeCodeCardType? SpeCodeCardType { get; set; }
        public string? Code { get; set; }
        public bool? Statu { get; set; }
        public bool? IsActive { get; set; }
    }
}
