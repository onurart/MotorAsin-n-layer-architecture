using MotorAsinBasketRobot.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorAsinBasketRobot.Entities.Dtos.Documents
{
    public class ListDocuments : IBaseDto, IStatu
    {
        public short? DocumetType { get; set; }
        public short? LineType { get; set; }
        public short? Billed { get; set; }
        public double? TlToltal { get; set; }
        public int? ProductReferance { get; set; }
        public int? CustomerReferance { get; set; }
        public DateTime? DocumentDate { get; set; }
    }
}
