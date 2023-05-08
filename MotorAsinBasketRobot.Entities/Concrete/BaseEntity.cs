using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class BaseEntity : IEntityDetail, IMultiTenant
    {
        //public DateTime CreatedDate { get; set; }
        //public Guid CreatorId { get; set; }
        //public DateTime? LastModificationTime { get; set; }
        //public Guid? LastModifierId { get; set; }
        public int Id { get; set; }
        //public Guid? TenantId { get; set; }
        public bool? IsActive { get; set; }
        public string? Code { get; set; }


    }
}
