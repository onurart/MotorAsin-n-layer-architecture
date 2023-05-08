using MotorAsinBasketRobot.Core.DataAccess.Utilities.Results;
using MotorAsinBasketRobot.Core.DataAccess.Utilities.Security.Jwt;
using MotorAsinBasketRobot.Core.Entities.Concrete;
using MotorAsinBasketRobot.Core.Entities.Dtos;
using MotorAsinBasketRobot.Core.Extensions;

namespace MotorAsinBasketRobot.Business.Abstract
{
    public interface IAuthService
    {
        Task<IDataResult<User>> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
