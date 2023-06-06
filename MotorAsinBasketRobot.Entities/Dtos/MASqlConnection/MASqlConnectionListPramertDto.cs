using MotorAsinBasketRobot.Core.Entities.Abstract;
using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.MASqlConnection
{
    public class MASqlConnectionListPramertDto : IBaseDto, IStatu
    {
        public bool Statu { get; set; }
        //public string? Code { get; set; }
        public bool? IsActive { get; set; }
        public EnmConnetion Connecion { get; set; }
        public DateTime? DateFilter { get; set; }
    }
}
