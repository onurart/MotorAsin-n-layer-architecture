using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.Entities.Abstract
{
    public interface IEntityDetail : IEntity
    {
        public int Id { get; set; }
    }
}
