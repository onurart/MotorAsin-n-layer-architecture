using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MotorAsinBasketProjectClient.UI.Extenisons;
using MotorAsinBasketRobot.Business.EmailService.IService;
using MotorAsinBasketRobot.Entities.Identity;
using MotorAsinBasketRobot.Entities.ViewModel;

namespace MotorAsinBasketProjectClient.UI.Controllers
{
    public class WebLoginController : Controller
    {
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailService _emailService;

        public WebLoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
        {
            _UserManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            returnUrl ??= Url.Action("AdminDashboard", "Admin");
            var hasUser = await _UserManager.FindByEmailAsync(model.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış");
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelErrorList(new List<string>() { "3 dakika boyunca giriş yapamazsınız." });
                return View();
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelErrorList(new List<string>() { $"Email veya şifre yanlış", $"Başarısız giriş sayısı = {await _UserManager.GetAccessFailedCountAsync(hasUser)}" });
                return View();
            }
            return Redirect(returnUrl!);
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel request)
         {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                var identityResult = await _UserManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, request.PasswordConfirm);
                if (!identityResult.Succeeded)
                {
                    ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
                    return View();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //var exchangeExpireClaim = new Claim("ExchangeExpireDate", DateTime.Now.AddDays(10).ToString());

            //var user = await _UserManager.FindByNameAsync(request.UserName);

            //var claimResult = await _UserManager.AddClaimAsync(user!, exchangeExpireClaim);


            //if (!claimResult.Succeeded)
            //{
            //    ModelState.AddModelErrorList(claimResult.Errors.Select(x => x.Description).ToList());
            //    return View();
            //}


            //TempData["SuccessMessage"] = "Üyelik kayıt işlemi başarıla gerçekleşmiştir.";

            return RedirectToAction(nameof(WebLoginController.SignIn));





        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
