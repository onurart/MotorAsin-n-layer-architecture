﻿using MotorAsinBasketRobot.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Business.Validator.Abstract
{
    public interface IBasketStatusValidator
    {
        Task CheckCreateAsync(string code);
        Task CheckUpdateAsync(int id, string code, BasketStatus entity);
    }
}
