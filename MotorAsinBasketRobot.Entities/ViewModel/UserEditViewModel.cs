using MotorAsinBasketRobot.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MotorAsinBasketRobot.Entities.ViewModel
{
    public class UserEditViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Ad alanı boş bırakılamaz.")]
        [Display(Name = "Kullanıcı Adı :")]
        public string UserName { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        [Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        [Display(Name = "Email :")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz.")]
        [Display(Name = "Telefon :")]
        public string Phone { get; set; } = null!;

        [DataType(DataType.Date)]
        [Display(Name = "Doğrum tarihi :")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Şehir :")]
        public string? City { get; set; }
        //[Display(Name = "Profil resmi :")]
        //public IFormFile? Picture { get; set; }
        [Display(Name = "Cinsiyet :")]
        public Gender? Gender { get; set; }
    }
}
