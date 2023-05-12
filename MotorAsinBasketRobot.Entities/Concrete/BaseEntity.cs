using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class BaseEntity : IEntityDetail//, IMultiTenant
    {
        public long Id { get; set; }
       // public long? TenantId { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public long? CreatorId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? LastModifiedId { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public long? DeletedId { get; set; }
        public DateTime? DeletedTime { get; set; }
    }
}
