using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.Entities.Concrete
{
    public class OperationClaim : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
