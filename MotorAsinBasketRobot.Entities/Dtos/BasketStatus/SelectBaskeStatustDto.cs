﻿using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.BasketStatus
{
    public class SelectBaskeStatustDto : IDto, ISpeCode
    {
        public string? ProductCode { get; set; }
        public string? CustomerCode { get; set; }
    }
}
