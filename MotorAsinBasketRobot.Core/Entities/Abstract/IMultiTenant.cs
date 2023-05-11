using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Core.Entities.Abstract
{
    public interface IMultiTenant
    {
        public long TenantId { get; set; }  
        public DateTime? TenantDate { get; set; }   
    }
}
