using MotorAsinBasketRobot.Core.Entities.Concrete;

namespace MotorAsinBasketRobot.Core.DataAccess.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
