using MotorAsinBasketRobot.Core.Entities.Abstract;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.SpeCodes
{
    public class SpeCodeParameterDto : IBaseDto, IStatu
    {
        public SpeCodeType? SpeCodeType { get; set; }
        public SpeCodeCardType? SpeCodeCardType { get; set; }
        public bool Statu { get; set; }
    }

}
