using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MotorAsinBasketRobot.Entities.ViewModel
{
    public class ResetPasswordViewModel
    {
        //[Required(ErrorMessage = "Email alanı boş bırakılamaz.")]
        //[EmailAddress(ErrorMessage = "Email formatı yanlıştır.")]
        //[Display(Name = "Email :")]
        //public string Email { get; set; } = null!;

        //[DataType(DataType.Password)]
        //[Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        //[Display(Name = "Yeni şifre :")]
        //public string Password { get; set; } = null!;


        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Yeni Şifre")]
        public string Password { get; set; } = null!;
        [Compare(nameof(Password), ErrorMessage = "Şifre  aynı değildir")]
        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz.")]
        [Display(Name = "Yeni Şifre tekrar")]
        public string PasswordConfirm { get; set; } = null!;

    }
}
