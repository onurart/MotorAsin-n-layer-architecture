using MotorAsinBasketRobot.Entities.Dtos.MASqlConnection.Generic;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.MASqlConnection.Customer.CustomerServer
{
    public class CreateCustomerServerMASqlConnectionDto : CreateMASqlConnectionDto
    {
        //private EnmConnetion? EnmConnetion { get; } = MotorAsinBasketProject.ViewModel.Enums.EnmConnetion.CustomerServerDb;
        private EnmConnetion? EnmConnetion { get; } = MotorAsinBasketRobot.Shared.Enums.EnmConnetion.CustomerServerDb;
    }
}
