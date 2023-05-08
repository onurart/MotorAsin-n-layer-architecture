using MotorAsinBasketRobot.Entities.Dtos.MASqlConnection.Generic;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.MASqlConnection.Customer.CustomerMotorasin
{
    public class CreateCustomerMotorasinMASqlConnectionDto : CreateMASqlConnectionDto
    {
        private EnmConnetion? EnmConnetion { get; } = MotorAsinBasketRobot.Shared.Enums.EnmConnetion.CustomerMotorasinDb;
    }
}
