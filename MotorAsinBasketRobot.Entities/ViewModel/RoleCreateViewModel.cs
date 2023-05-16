using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MotorAsinBasketRobot.Entities.ViewModel
{
    public class RoleCreateViewModel
    {
        [Required(ErrorMessage = "Role isim alanı boş bırakılamaz.")]
        [Display(Name = "Role ismi :")]
        public string Name { get; set; }
    }
}
