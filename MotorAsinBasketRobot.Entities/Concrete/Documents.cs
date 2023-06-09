using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Concrete
{
    public class Documents : BaseEntity
    {
        public short? DocumetType { get; set; }
        public short? LineType { get; set; }
        public short? Billed { get; set; }
        public int Quantity { get; set; }
        public double? TlToltal { get; set; }
        public int? ProductReferance { get; set; }
        public int? CustomerReferance { get; set; }
        public string? DocumentNo { get; set; }
        public DateTime? DocumentDate { get; set; }
        [JsonIgnore]
        public string? Content { get; set; }
        [JsonIgnore]
        public string? FileName { get; set; }
        [ForeignKey("CustomerReferance")]
        public Customer Customer { get; set; }
        [ForeignKey("ProductReferance")]
        public Product Product { get; set; }
    }
}
