using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class MASqlConnection : BaseEntity
    {
        public EnmConnetion? EnmConnetion { get; set; }
        public string? CustomerCode { get; set; }
        public string? ServerName { get; set; }
        public string? DbName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Encrypt { get; set; }
        public string? Failover { get; set; }
        public string? Certificate { get; set; }
        public string? ApplicationIntent { get; set; }
    }
}
