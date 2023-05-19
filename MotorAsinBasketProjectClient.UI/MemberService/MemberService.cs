using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;
using MotorAsinBasketRobot.Entities.Identity;
using MotorAsinBasketRobot.Entities.ViewModel;
using System.Security.Claims;

namespace MotorAsinBasketProjectClient.UI.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IFileProvider _fileProvider;
        public MemberService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IFileProvider fileProvider)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _fileProvider = fileProvider;
        }
        public Task<(bool, IEnumerable<IdentityError>?)> ChangePasswordAsync(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPasswordAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, IEnumerable<IdentityError>?)> EditUserAsync(UserEditViewModel request, string userName)
        {
            throw new NotImplementedException();
        }

        public List<ClaimViewModel> GetClaims(ClaimsPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public SelectList GetGenderSelectList()
        {
            throw new NotImplementedException();
        }

        public Task<UserEditViewModel> GetUserEditViewModelAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserViewModel> GetUserViewModelByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
